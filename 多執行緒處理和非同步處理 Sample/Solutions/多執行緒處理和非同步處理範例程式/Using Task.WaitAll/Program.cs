using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_Task.WaitAll
{
    // 因為採用 Thread 方式來同步執行，所以，每次執行結果有可能會不一樣
    public static class Program
    {
        public static void Main()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            }
            );
            Task.WaitAll(tasks);

            Console.ReadKey();
        }
    }
}
