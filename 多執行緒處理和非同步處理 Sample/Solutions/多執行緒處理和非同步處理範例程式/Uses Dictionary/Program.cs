using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uses_Dictionary
{
    class Program
    {
        static Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        static void Main()
        {
            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(A));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Average: {0}", _dictionary.Values.Average());
            Console.ReadKey();
        }

        static void A()
        {
            for (int i = 0; i < 1000; i++)
            {
                // we use the Add method. 
                // The Dictionary program will fail—you cannot Add an existing element.
                _dictionary.Add(i.ToString(), i);
            }
        }
    }
}
