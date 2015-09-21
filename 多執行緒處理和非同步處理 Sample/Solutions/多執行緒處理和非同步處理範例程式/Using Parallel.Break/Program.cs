using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_Parallel.Break
{
    // You have two options to do this: Break or Stop. Break ensures that all iterations that are currently running will be finished. Stop just terminates everything
    class Program
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.
                For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        loopState.Break();
                        //loopState.Stop();
                    }
                    return;
                });

            Console.WriteLine("IsCompleted:{0} " + result.IsCompleted);
            Console.WriteLine("LowestBreakIteration:{0} " + result.LowestBreakIteration);
            Console.ReadKey();
        }
    }
}
