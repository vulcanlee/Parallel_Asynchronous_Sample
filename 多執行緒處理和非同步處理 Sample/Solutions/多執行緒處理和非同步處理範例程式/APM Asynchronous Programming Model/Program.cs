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

    class Program
    {
        static void Main(string[] args)
        {
            string queryFQDN = "http://www.microsoft.com/";
            RequestState myRequestState = new RequestState();
            myRequestState.request = (HttpWebRequest)WebRequest.Create(queryFQDN);
            IAsyncResult ar = myRequestState.request.BeginGetResponse(new AsyncCallback(ResponseCallback), myRequestState);
            Console.ReadKey();
        }

        static void ResponseCallback(IAsyncResult ar)
        {
            Console.WriteLine("Request completed.");
            RequestState myRequestState = (RequestState)ar.AsyncState;
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