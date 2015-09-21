using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starting_a_new_Task_using_TaskFactory
{
    class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.Name = "Main";

            // Better: Create and start the task in one operation. 
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA."));

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                              Thread.CurrentThread.Name);

            taskA.Wait();
            Console.ReadKey();
        }
    }
}
