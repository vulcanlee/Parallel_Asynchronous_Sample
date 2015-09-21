using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Creating_a_thread_with_the_Thread_class
{
    public static class Program
    {
        // Thread 使用的方法
        // 不同執行緒若都有執行到 Console.Write，則，當Console正在輸出的時候，其他執行緒必須等候。
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // 告知作業系統，這個 Thread 可用片段時間已經處理完成所有工作，可以提早切換到其他Thread了
                // 執行緒會將其剩餘的時間配量讓與準備好要執行的任何同等優先權執行緒
                // https://msdn.microsoft.com/zh-tw/library/d00bd51t(v=vs.110).aspx
                Thread.Sleep(0);
            }
        }
        public static void Main()
        {
            // 產生一個新的 Thread，當該Thread啟動之後，會執行 [ThreadMethod] 方法
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            // 為Thread加入名稱，方便進行除錯
            // 要查看執行中的 Thread 請在功能表中選擇 偵錯 > 視窗 > 執行緒
            t.Name = "多奇經驗分享執行緒";
            t.Start();
            // 當 Thread 正在執行的同時，主要 Thread 也正在執行，也就是說，兩個 Thread同時在執行中，
            // 每個 Thread 在執行過程中，只能夠使用到片段的CPU時間，使用完後，就需要切換到別的Thread上，讓其他Thread可以來執行
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                // 告知作業系統，這個 Thread 可用片段時間已經處理完成所有工作，可以提早切換到其他Thread了
                // 執行緒會將其剩餘的時間配量讓與準備好要執行的任何同等優先權執行緒
                Thread.Sleep(0);
            }
            // 等候該Thread執行完畢，此時，主要執行緒將無法處理任何事情，只有等候
            // https://msdn.microsoft.com/zh-tw/library/95hbf2ta(v=vs.110).aspx
            t.Join();
            Console.ReadKey();
        }
    }
}
