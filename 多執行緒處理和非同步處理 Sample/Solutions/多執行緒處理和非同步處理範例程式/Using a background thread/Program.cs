using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_a_background_thread
{
    // Only when all foreground threads end does the common language runtime (CLR) shut down your application. Background threads are then terminated
    // 啟動 Thread，並且指定皆為 Background Thread
    // 因為在 Main 中，只是啟動該Thread，之後 主要 Thread 就會結束了，因此，不等到 Background Thread 結束，App會自動終止所有的 Thread
    class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Main()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            //t.IsBackground = false;
            t.Start();
        }
    }
}
