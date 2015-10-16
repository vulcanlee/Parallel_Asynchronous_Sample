﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TAP_Task_based_Asynchronous_Pattern
{
    /// <summary>
    /// 這個專案說明了如何使用 TAP Task-based Asynchronous Pattern 來呼叫非同步的工作
    /// 在這個設計模式下，我們不需要呼叫 BeginXXX/EndXXX，也不再需要透過事件 Call Back來得知是否工作完成，
    /// 取而代之的是，我們不再需要使用任何複雜的非同步程式設計方式來寫程式碼，而是使用同步的方式來寫程式，
    /// 但寫出來的程式是具有非同步效果，並且不會造成 Thread Block
    /// </summary>
    class Program
    {
        // 請觀察除錯點上的 Thread ID
        static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com";

            // 注意下列並沒有使用 await，這是因為在App的 Entry Point內，無法使用 Async關鍵字
            // Wait : 候 System.Threading.Tasks.Task 完成執行，這個方法會造成呼叫端的Thread會被 Block
            DownloadHtmlAsyncTask(queryFQDN).Wait() ;

            //Task fooTask = DownloadHtmlAsyncTask(queryFQDN);
            //fooTask.Wait();

            Console.ReadKey();
        }

        // 這個方法使用了 Async 關鍵字，而在這個方法內部，可以使用 Await 關鍵字來呼叫其他非同步工作
        // 我們在此使用了同步邏輯來寫出非同步處理效果，而且不會造成Block
        // 會有這這樣的效果，那是因為，編譯器幫我們重新改寫了 DownloadHtmlAsyncTask 這個非同步方法，
        // 所有，可以得到這樣的好處
        public static async Task<string> DownloadHtmlAsyncTask(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("before await");
            // 使用 Await 關鍵字，告知編譯器，我們準備要進入到非同步處理，取得遠端網頁內容
            // 此時，呼叫端的Thread不會被 Block，從這個呼叫點回到上層呼叫端
            // 一旦非同步工作處理完成後，就會切換到這裡，繼續執行下去，我們不再需要處理任何相關工作
            // 也不會造成任何資源被鎖定
            string result = await httpClient.GetStringAsync(url);
            // 當上述程式碼執行完成後，就會取得遠端網頁的內容，並且儲存在 resutl 變數內
            Console.WriteLine("after await");
            Console.WriteLine(result);
            return result;
        }
    }
}
