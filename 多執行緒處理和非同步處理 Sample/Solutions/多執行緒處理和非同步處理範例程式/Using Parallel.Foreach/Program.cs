using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_Parallel.Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch;
            int sleepTime = 300;
            int loopTimes = 100;
            watch = new Stopwatch();
            watch.Start();

            Parallel.For(0, loopTimes, i =>
            {
                Thread.Sleep(sleepTime);
            });
            watch.Stop();
            Console.WriteLine("Parallel.For Time: " + watch.Elapsed.Seconds.ToString());

            var numbers = Enumerable.Range(0, loopTimes);
            watch = new Stopwatch();
            watch.Start();
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(sleepTime);
            });
            watch.Stop();
            Console.WriteLine("Parallel.ForEach Time: " + watch.Elapsed.Seconds.ToString());

            Console.ReadKey();
        }
    }
}
