using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_Parallel.For
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch;
            int sleepTime = 300;
            int loopTimes = 10;
            watch = new Stopwatch();
            watch.Start();

            //serial implementation
            for (int i = 0; i < loopTimes; i++)
            {
                Thread.Sleep(sleepTime);
                //Do stuff
            }
            watch.Stop();
            Console.WriteLine("Serial Time: " + watch.Elapsed.Seconds.ToString());

            //parallel implementation
            watch = new Stopwatch();
            watch.Start();
            System.Threading.Tasks.Parallel.For(0, loopTimes, i =>
            {
                Thread.Sleep(sleepTime);
                //Do stuff with i
            }
            );
            watch.Stop();
            Console.WriteLine("Parallel Time: " + watch.Elapsed.Seconds.ToString());

            Console.ReadLine();
        }
    }
}
