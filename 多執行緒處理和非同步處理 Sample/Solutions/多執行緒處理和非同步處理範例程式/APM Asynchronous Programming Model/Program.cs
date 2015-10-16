using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APM_Asynchronous_Programming_Model
{
    class RequestState
    {
        public HttpWebRequest request = null;
        public HttpWebResponse response = null;
    }

    /// <summary>
    /// 這是 APM Asynchronous Programming Model 的使用範例
    /// 在這裡使用了 HttpRequest 來進行讀取遠端網頁(www.microsoft.com)上的內容
    /// APM 的特色就是 使用 BeginXXX 方法啟動非同步的呼叫，完成後，使用 EndXXX結束非同步呼叫並且取得結果內容
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com/";
            RequestState myRequestState = new RequestState();
            myRequestState.request = (HttpWebRequest)WebRequest.Create(queryFQDN);
            // 這裡呼叫了 BeginGetResponse (BeginXXX ) 開始對網際網路資源的非同步要求
            // 呼叫的時候，也指定了 System.AsyncCallback 委派，要來指派當非同步工作完成的後，需要呼叫的方法
            // 回傳值為 IAsyncResult 類型，參考回應的非同步要求
            IAsyncResult ar = myRequestState.request.BeginGetResponse(new AsyncCallback(ResponseCallback), myRequestState);
            Console.ReadKey();
        }

        static void ResponseCallback(IAsyncResult ar)
        {
            Console.WriteLine("Request completed.");
            RequestState myRequestState = (RequestState)ar.AsyncState;
            // 當完成了非同步呼叫，這裡使用了 EndGetResponse (EndXXX) 結束對網際網路資源的非同步要求，
            // EndGetResponse 會回傳包含來自網際網路資源的回應，如此，我們就可以透過這個回傳值，
            // 判斷此次非同步存取是否成功、以及結果內容
            myRequestState.response = (HttpWebResponse)myRequestState.request.EndGetResponse(ar);

            Encoding enc = System.Text.Encoding.UTF8;
            StreamReader loResponseStream = new
              StreamReader(myRequestState.response.GetResponseStream(), enc);

            string Response = loResponseStream.ReadToEnd();
            Console.WriteLine(Response);

            loResponseStream.Close();
            myRequestState.response.Close();

        }
    }
}