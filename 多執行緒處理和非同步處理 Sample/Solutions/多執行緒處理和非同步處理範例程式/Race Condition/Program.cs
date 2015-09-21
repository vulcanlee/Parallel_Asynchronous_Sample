using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race_Condition
{
    // This application uses the Test class to print 10 numbers by pause the current thread for a random number of times
    public class Test
    {
        //public void Calculation()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(new Random().Next(5));
        //        Console.WriteLine("{0}[{1}] ,", i,Thread.CurrentThread.Name);
        //    }
        //    Console.WriteLine();
        //}



        public object tLock = new object();

        public void Calculation()
        {
            lock (tLock)
            {
                Console.Write(" {0} is Executing", Thread.CurrentThread.Name);

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.WriteLine("{0}[{1}] ,", i, Thread.CurrentThread.Name); ;
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread[] tr = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(t.Calculation));
                tr[i].Name = String.Format("Working Thread: {0}", i);
            }

            //Start each thread
            foreach (Thread x in tr)
            {
                x.Start();
            }
            Console.ReadKey();
        }
    }
}
