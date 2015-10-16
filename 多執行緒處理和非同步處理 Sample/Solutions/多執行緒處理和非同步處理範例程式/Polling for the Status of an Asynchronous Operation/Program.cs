using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Polling_for_the_Status_of_an_Asynchronous_Operation
{
    // 輪詢非同步作業的狀態
    // 
    // 下列程式碼範例會示範使用 Dns 類別中的非同步方法，以擷取使用者指定之電腦的網域名稱系統資訊。 
    // 這個範例會啟動非同步作業，然後會在作業完成之前在主控台列印句號 (".")。 請注意，
    // null (在 Visual Basic 中為 Nothing) 會傳遞給 BeginGetHostByNameAsyncCallback 和 Object 參數，
    // 因為在使用這個方法時，並不需要這些引數。
    public class PollUntilOperationCompletes
    {
        static void UpdateUserInterface()
        {
            // Print a period to indicate that the application
            // is still working on the request.
            Console.Write(".");
        }
        public static void Main(string[] args)
        {
            string queryFQDN = "www.microsoft.com";

            // Start the asychronous request for DNS information.
            // 呼叫 BeginXXX 啟動非同步工作
            IAsyncResult result = Dns.BeginGetHostEntry(queryFQDN, null, null);
            Console.WriteLine("Processing request for information...");

            // Poll for completion information.
            // Print periods (".") until the operation completes.
            // 在這個回圈內，會不斷地查看非同步工作是否已經完成，透過 IsCompleted 成員
            // 這樣做法雖然不會造成 Thread Block，可以，可以看得出來，這樣做法會耗用大量的 CPU 資源
            // 因為，我們需要不斷的察看非同步工作是否已經完成
            while (result.IsCompleted != true)
            {
                UpdateUserInterface();
            }

            // The operation is complete. Process the results.
            // 若程式已經可以執行到這裡，那就表示非同步工作已經完成了
            // Print a new line.
            Console.WriteLine();
            try
            {
                // 透過 EndXXX 告知非同步工作已經完成，並且取得非同步工作的最後執行結果內容
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        Console.WriteLine("{0}", aliases[i]);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        Console.WriteLine("{0}", addresses[i].ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message);
            }
            Console.ReadKey();
        }
    }
}
