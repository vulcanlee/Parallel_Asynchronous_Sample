using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_the_ThreadStaticAttribute
{
    public static class Program
    {
        // 嘗試移除這個 Attribute 看看結果
        // 指示每個執行緒的靜態欄位值是唯一的。
        // https://msdn.microsoft.com/zh-tw/library/system.threadstaticattribute(v=vs.110).aspx
        [ThreadStatic]
        public static int _field;
        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();
            new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                _field++;
                Console.WriteLine("Thread B: {0}", _field);
            }
        }).Start();
            Console.ReadKey();
        }
    }
}
