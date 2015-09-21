using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Blocking_Application_Execution_Using_an_AsyncWaitHandle
{
    // 使用 AsyncWaitHandle 封鎖應用程式執行
    //
    // 下列程式碼範例會示範在 DNS 類別中使用非同步方法，以擷取使用者所指定之電腦的網域名稱系統資訊。 
    // 且會示範使用與非同步作業關聯的 WaitHandle 來進行封鎖。 
    // 請注意，由於在使用此處理方法時不需要 BeginGetHostByNamerequestCallback 和 stateObject 參數，
    // 對於這兩個參數都會傳遞 null (Visual Basic 中的 Nothing)。
    public class WaitUntilOperationCompletes
    {
        public static void Main(string[] args)
        {
            string queryFQDN = "www.microsoft.com";

            // Start the asynchronous request for DNS information.
            IAsyncResult result = Dns.BeginGetHostEntry(queryFQDN, null, null);
            Console.WriteLine("Processing request for information...");
            // Wait until the operation completes.
            result.AsyncWaitHandle.WaitOne();

            // The operation completed. Process the results.
            try
            {
                // Get the results.
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
                Console.WriteLine("Exception occurred while processing the request: {0}",
                    e.Message);
            }
            Console.ReadKey();
        }
    }
}
