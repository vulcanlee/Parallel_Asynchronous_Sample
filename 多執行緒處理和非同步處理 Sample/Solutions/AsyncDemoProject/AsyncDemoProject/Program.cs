using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new AsyncDemo();
            demo.GetStringAsync();

            while (demo.IsLoading)
            {
                Console.WriteLine("Async is Amazing no?!!!");
            }

            Console.ReadLine();
        }
    }

    class AsyncDemo
    {
        public bool IsLoading { get; set; }
        public async Task GetStringAsync()
        {
            IsLoading = true;

            var result = await GetStringTask();

            IsLoading = false;
            Console.WriteLine(result);
        }

        public Task<string> GetStringTask()
        {
            return Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);

                return "Hello World";
            });
        }
    }
}
