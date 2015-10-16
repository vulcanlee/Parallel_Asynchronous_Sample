using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EAP_Event_based_Asynchronous_Pattern
{
    /// <summary>
    /// 這是使用 EAP Event-based Asynchronous Pattern 範例
    /// 這個樣式特色為啟動非同步呼叫之後，就會再另外一個 Thread 繼續來執行這些非同步的需求，不會封鎖呼叫執行緒
    /// 當完成之後，會透過 Call Back來繼續處理相關工作，而是否完成與完成的結果內容，可以透過這個委派事件參數取得
    /// </summary>
    class Program
    {
        // 請觀察除錯點上的 Thread ID
        public static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com/";

            var wc = new WebClient();
            // 指定當 在非同步資源下載作業完成時發生 ，要執行的委派方法
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;

            //wc.DownloadStringCompleted += (s, e) =>
            //{
            //    if (e.Error != null) Console.WriteLine(e.Error);
            //    else if (e.Cancelled) Console.WriteLine("Cancel");
            //    else Console.WriteLine(e.Result);
            //};

            // 下載指定的資源做為 System.Uri。這個方法不會封鎖呼叫執行緒
            wc.DownloadStringAsync(new Uri(queryFQDN));
            Console.ReadKey();
        }

        private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // 完成非同步呼叫之後，可以透過委派事件內的參數，取得此次非同步工作的失敗/成功狀態，完成結果內容
            if (e.Error != null) Console.WriteLine(e.Error);
            else if (e.Cancelled) Console.WriteLine("Cancel");
            else Console.WriteLine(e.Result);
        }
    }
}
