using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starting_a_new_Task
{
    // Executing a Task on another thread makes sense only if 
    // you want to keep the user interface thread free for other work or if 
    // you want to parallelize your work on to multiple processors.
    public static class Program
    {
        public static void Main()
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write("*");
                }
            });
            t.Wait();
            Console.ReadKey();
        }
    }
}
