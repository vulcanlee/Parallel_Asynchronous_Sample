using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uses_ConcurrentDictionary
{
    class Program
    {
        static ConcurrentDictionary<string, int> _concurrent =
            new ConcurrentDictionary<string, int>();

        static void Main()
        {
            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(A));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Average: {0}", _concurrent.Values.Average());
            Console.ReadKey();
        }

        static void A()
        {
            for (int i = 0; i < 1000; i++)
            {
                //  we use the TryAdd method. This does nothing if the key is already found. It returns true if something was added
                _concurrent.TryAdd(i.ToString(), i);
            }
        }
    }
}
