using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduling_different_continuation_tasks
{
    public enum TaskAction
    {
        Complete,
        Cancel,
        Faulted
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            // 修改這裡，查看不同的 Task 執行結果
            TaskAction fooTaskAction = TaskAction.Faulted;

            Task<int> t = Task.Run(async () =>
            {
                await Task.Delay(1000);
                if(fooTaskAction == TaskAction.Faulted)
                {
                    throw new Exception("唉，真糟糕呀，真糟糕");
                }
                return 42;
            }, token);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted:{0}", i.Exception.InnerExceptions[0].Message);
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            switch (fooTaskAction)
            {
                case TaskAction.Complete:
                    completedTask.Wait();
                    break;
                case TaskAction.Cancel:
                    tokenSource.Cancel();
                    break;
                case TaskAction.Faulted:
                    break;
            }

            Console.ReadKey();
        }
    }
}
