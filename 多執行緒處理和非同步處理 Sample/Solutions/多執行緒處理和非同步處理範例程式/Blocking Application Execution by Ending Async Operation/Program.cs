using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Blocking_Application_Execution_by_Ending_Async_Operation
{
    // 以結束非同步作業的方式封鎖應用程式執行
    // 
    // 下列程式碼範例會示範使用 Dns 類別中的非同步方法，以擷取使用者指定之電腦的網域名稱系統資訊。 
    // 請注意，null (在 Visual Basic 中為 Nothing) 會傳遞給 BeginGetHostByNamerequestCallback 和 stateObject 參數，
    // 因為在使用這個方法時，並不需要這些引數。
    class Program
    {
        public class BlockUntilOperationCompletes
        {
            public static void Main(string[] args)
            {

                string queryFQDN = "www.microsoft.com";

                // Start the asynchronous request for DNS information.
                // This example does not use a delegate or user-supplied object
                // so the last two arguments are null.
                IAsyncResult result = Dns.BeginGetHostEntry(queryFQDN, null, null);
                Console.WriteLine("Processing your request for information...");
                // Do any additional work that can be done here.
                try
                {
                    // EndGetHostByName blocks until the process completes.
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
}
