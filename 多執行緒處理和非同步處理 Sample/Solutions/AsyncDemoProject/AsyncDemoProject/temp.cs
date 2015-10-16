using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemoProject
{
    internal class AsyncDemo
    {
        // d__4 這個方法是由編譯器產生的
        [CompilerGenerated]
        private sealed class <GetStringAsync>d__4 : IAsyncStateMachine
		{
			public int <>1__state;

			public AsyncTaskMethodBuilder<> t__builder;

        public AsyncDemo<>4__this;

			private string <result>5__1;

			private string <>s__2;

			private TaskAwaiter<string> <>u__1;

			void IAsyncStateMachine.MoveNext()
        {
            int num = this.<> 1__state;
            try
            {
                TaskAwaiter<string> taskAwaiter;
                if (num != 0)
                {
                    this.<> 4__this.IsLoading = true;
                    taskAwaiter = this.<> 4__this.GetStringTask().GetAwaiter();
                    if (!taskAwaiter.IsCompleted)
                    {
                        this.<> 1__state = 0;
                        this.<> u__1 = taskAwaiter;
                        AsyncDemo.< GetStringAsync > d__4 < GetStringAsync > d__ = this;
                        this.<> t__builder.AwaitUnsafeOnCompleted < TaskAwaiter<string>, AsyncDemo.< GetStringAsync > d__4 > (ref taskAwaiter, ref < GetStringAsync > d__);
                        return;
                    }
                }
                else
                {
                    taskAwaiter = this.<> u__1;
                    this.<> u__1 = default(TaskAwaiter<string>);
                    this.<> 1__state = -1;
                }
                string result = taskAwaiter.GetResult();
                taskAwaiter = default(TaskAwaiter<string>);
                this.<> s__2 = result;
                this.< result > 5__1 = this.<> s__2;
                this.<> s__2 = null;
                this.<> 4__this.IsLoading = false;
                Console.WriteLine(this.< result > 5__1);
            }
            catch (Exception exception)
            {
                this.<> 1__state = -2;
                this.<> t__builder.SetException(exception);
                return;
            }
            this.<> 1__state = -2;
            this.<> t__builder.SetResult();
        }

        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }

    [CompilerGenerated]
    [Serializable]
    private sealed class <>c
		{
			public static readonly AsyncDemo.<>c<>9 = new AsyncDemo.<>c();

    public static Func<string> <>9__5_0;

			internal string <GetStringTask>b__5_0()
    {
        Thread.Sleep(2000);
        return "Hello World";
    }
}

public bool IsLoading
{
    get;
    set;
}

[DebuggerStepThrough, AsyncStateMachine(typeof(AsyncDemo.< GetStringAsync > d__4))]
public Task GetStringAsync()
{
    AsyncDemo.< GetStringAsync > d__4 < GetStringAsync > d__ = new AsyncDemo.< GetStringAsync > d__4();
            < GetStringAsync > d__.<> 4__this = this;
            < GetStringAsync > d__.<> t__builder = AsyncTaskMethodBuilder.Create();
            < GetStringAsync > d__.<> 1__state = -1;
    AsyncTaskMethodBuilder<> t__builder = < GetStringAsync > d__.<> t__builder;
            <> t__builder.Start < AsyncDemo.< GetStringAsync > d__4 > (ref < GetStringAsync > d__);
    return < GetStringAsync > d__.<> t__builder.Task;
}

public Task<string> GetStringTask()
{
    TaskFactory<string> arg_25_0 = Task<string>.Factory;
    Func<string> arg_25_1;
    if ((arg_25_1 = AsyncDemo.<> c.<> 9__5_0) == null)
			{
        arg_25_1 = (AsyncDemo.<> c.<> 9__5_0 = new Func<string>(AsyncDemo.<> c.<> 9.< GetStringTask > b__5_0));
    }
    return arg_25_0.StartNew(arg_25_1);
}
	}
}
