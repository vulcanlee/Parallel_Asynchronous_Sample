using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race_Condition_using_lock_keyword
{
    public class RaceConditionsSampleFixWithLock
    {
        private static int counter = 0;

        private static object staticObjLock = new object();

        public static void Main()
        {
            // Initialize thread with address of DoWork1
            Thread thread1 = new Thread(DoWork1);

            // Initilaize thread with address of DoWork1
            Thread thread2 = new Thread(DoWork1);

            // Start the Threads.
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Done Processing...");
            Console.WriteLine(counter);
            Console.ReadKey();
        }

        private static void DoWork1()
        {
            for (int index = 0; index < 2000000; index++)
            {
                // Actually we can apply lock on entire for loop.
                // This is only for demo purposes.
                // It is not a good idea to lock so many times.
                lock (staticObjLock)
                {
                    counter++;
                }
            }
        }
    }
}
