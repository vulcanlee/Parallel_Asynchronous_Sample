using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EAP_Event_based_Asynchronous_Pattern
{
    class Program
    {
        // 請觀察除錯點上的 Thread ID
        public static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com/";

            var wc = new WebClient();
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            //wc.DownloadStringCompleted += (s, e) =>
            //{
            //    if (e.Error != null) Console.WriteLine(e.Error);
            //    else if (e.Cancelled) Console.WriteLine("Cancel");
            //    else Console.WriteLine(e.Result);
            //};
            wc.DownloadStringAsync(new Uri(queryFQDN));
            Console.ReadKey();
        }

        private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null) Console.WriteLine(e.Error);
            else if (e.Cancelled) Console.WriteLine("Cancel");
            else Console.WriteLine(e.Result);
        }
    }
}
