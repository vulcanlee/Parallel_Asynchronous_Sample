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
            IAsyncResult result = Dns.BeginGetHostEntry(queryFQDN, null, null);
            Console.WriteLine("Processing request for information...");

            // Poll for completion information.
            // Print periods (".") until the operation completes.
            while (result.IsCompleted != true)
            {
                UpdateUserInterface();
            }
            // The operation is complete. Process the results.
            // Print a new line.
            Console.WriteLine();
            try
            {
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
