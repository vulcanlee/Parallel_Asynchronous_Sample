using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queuing_some_work_to_the_thread_pool
{
    class Program
    {
        /// <summary>
        /// When you work with a thread pool from .NET, you queue a work item that is then picked up by an available thread from the pool
        /// https://msdn.microsoft.com/en-us/library/system.threading.threadpool.aspx
        /// </summary>
        public static void Main()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }
    }
}
