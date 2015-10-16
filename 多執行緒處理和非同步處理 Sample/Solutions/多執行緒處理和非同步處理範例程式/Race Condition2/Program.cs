using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race_Condition2
{
    // In a multithreaded program shared resources can be accessed by threads concurrently, this could lead to Race Conditions.
    // This will lead to unpredictable value in the shared variable as the programmer does not have control on the order in which 
    // the shared variable is assessed by the working threads.
    public class RaceConditionsSample
    {
        private static int counter = 0;
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
            for (int index = 0; index < 10000000; index++)
            {
                counter++;
            }
        }
    }
}
