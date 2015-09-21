using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryUpdate_ConcurrentDictionary
{
    class Program
    {
        static void Main()
        {
            // New instance.
            var con = new ConcurrentDictionary<string, int>();
            con.TryAdd("cat", 1);
            con.TryAdd("dog", 2);

            // Try to update if value is 4 (this fails).
            con.TryUpdate("cat", 200, 4);

            // Try to update if value is 1 (this works).
            con.TryUpdate("cat", 100, 1);

            // Write new value.
            Console.WriteLine(con["cat"]);
            Console.ReadKey();
        }
    }
}
