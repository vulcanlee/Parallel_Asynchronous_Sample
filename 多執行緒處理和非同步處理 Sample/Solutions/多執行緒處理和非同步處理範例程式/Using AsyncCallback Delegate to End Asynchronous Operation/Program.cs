using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_AsyncCallback_Delegate_to_End_Asynchronous_Operation
{
    // 使用 AsyncCallback 委派結束非同步作業
    //
    // 下列程式碼範例會示範使用 Dns 類別中的非同步方法，以擷取使用者指定之電腦的網域名稱系統 (DNS) 資訊。 
    // 此範例會建立參考 ProcessDnsInformation 方法的 AsyncCallback 委派。
    // 這個方法會對 DNS 資訊的每個非同步要求都呼叫一次。
    //
    // 請注意，使用者指定的主機會傳遞到 BeginGetHostByNameObject 參數。 
    // 如需定義和使用更為複雜狀態物件的範例，請參閱使用 AsyncCallback 委派和狀態物件。
    class Program
    {
        public class UseDelegateForAsyncCallback
        {
            static int requestCounter;
            static ArrayList hostData = new ArrayList();
            static StringCollection hostNames = new StringCollection();
            static void UpdateUserInterface()
            {
                // Print a message to indicate that the application
                // is still working on the remaining requests.
                Console.WriteLine("{0} requests remaining.", requestCounter);
            }
            public static void Main()
            {
                // Create the delegate that will process the results of the 
                // asynchronous request.
                AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation);

                string queryFQDN = "www.microsoft.com";

                string host;
                // 在這個迴圈內，我們可以輸入多個 URL，程式會立即啟動非同步工作取得該 URL 的內容
                do
                {
                    Console.Write(" Enter the name of a host computer or <enter> to finish: ");
                    host = Console.ReadLine();
                    if (host.Length > 0)
                    {
                        // Increment the request counter in a thread safe manner.

                        //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
                        // 遞增特定變數並將結果儲存起來，成為不可部分完成的作業。
                        // 在進行多執行緒存取分享資源的時候，尤其要特別注意
                        //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊

                        Interlocked.Increment(ref requestCounter);
                        // Start the asynchronous request for DNS information.
                        // 呼叫 BeginXXX 啟動非同步工作
                        Dns.BeginGetHostEntry(host, callBack, host);
                    }
                } while (host.Length > 0);

                //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
                // 每次非同步作業完成後， requestCounter的就會減少一，由此判斷所有的非同步作業是否都已經完成
                // 這樣的迴圈，也會造成系統資訊濫用
                //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊

                // 
                // The user has entered all of the host names for lookup.
                // Now wait until the threads complete.
                // 該迴圈的用意，僅是當所有非同步工作都處理完成之後，才會繼續執行該迴圈後的程式碼，
                // 也就是列出所有非同步執行結果的內容
                while (requestCounter > 0)
                {
                    UpdateUserInterface();
                }

                // Display the results.
                for (int i = 0; i < hostNames.Count; i++)
                {
                    object data = hostData[i];
                    string message = data as string;
                    // A SocketException was thrown.
                    if (message != null)
                    {
                        Console.WriteLine("Request for {0} returned message: {1}",
                            hostNames[i], message);
                        continue;
                    }
                    // Get the results.
                    IPHostEntry h = (IPHostEntry)data;
                    string[] aliases = h.Aliases;
                    IPAddress[] addresses = h.AddressList;
                    if (aliases.Length > 0)
                    {
                        Console.WriteLine("Aliases for {0}", hostNames[i]);
                        for (int j = 0; j < aliases.Length; j++)
                        {
                            Console.WriteLine("{0}", aliases[j]);
                        }
                    }
                    if (addresses.Length > 0)
                    {
                        Console.WriteLine("Addresses for {0}", hostNames[i]);
                        for (int k = 0; k < addresses.Length; k++)
                        {
                            Console.WriteLine("{0}", addresses[k].ToString());
                        }
                    }
                }
                Console.ReadKey();

            }

            // The following method is called when each asynchronous operation completes.
            static void ProcessDnsInformation(IAsyncResult result)
            {
                // 當這段程式碼開始被執行到的時候，就表示某個非同步工作已經完成了
                string hostName = (string)result.AsyncState;
                hostNames.Add(hostName);
                try
                {
                    // Get the results.
                    // 我們需要透過呼叫 EndXXX 來取得非同步處理工作的完成結果內容
                    IPHostEntry host = Dns.EndGetHostEntry(result);
                    hostData.Add(host);
                }
                // Store the exception message.
                catch (SocketException e)
                {
                    hostData.Add(e.Message);
                }
                finally
                {
                    // Decrement the request counter in a thread-safe manner.
                    Interlocked.Decrement(ref requestCounter);
                }
            }
        }
    }
}
