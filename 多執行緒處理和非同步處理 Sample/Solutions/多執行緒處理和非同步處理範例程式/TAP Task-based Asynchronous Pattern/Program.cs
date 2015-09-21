using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TAP_Task_based_Asynchronous_Pattern
{
    class Program
    {
        // 請觀察除錯點上的 Thread ID
        static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com";

            // 注意下列並沒有使用 await
            DownloadHtmlAsyncTask(queryFQDN).Wait() ;

            //Task fooTask = DownloadHtmlAsyncTask(queryFQDN);
            //fooTask.Wait();
            Console.ReadKey();
        }

        public static async Task<string> DownloadHtmlAsyncTask(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("before await");
            string result = await httpClient.GetStringAsync(url);
            Console.WriteLine("after await");
            Console.WriteLine(result);
            return result;
        }
    }
}
