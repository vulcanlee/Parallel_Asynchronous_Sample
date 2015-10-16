//using System;
//using System.CodeDom.Compiler;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Markup;

//namespace AsyncAwait
//{
//    public class MainWindow : Window, IComponentConnector
//    {
//        // 這是編譯器產生出來的類別，用來處理非同步需求的狀態機
//        [CompilerGenerated]
//        private sealed class <btnDownload_Click>d__1 : IAsyncStateMachine
//		{
//            // 該 State Machine 狀態值
//		    public int <>1__state;

//            // 建立 AsyncTaskMethodBuilder 類別的執行個體
//		    public AsyncVoidMethodBuilder<> t__builder;

//            // 該事件的 sender 物件
//            public object sender;

//            // 該事件的 RoutedEventArgs 物件
//            public RoutedEventArgs e;

//            // 呼叫非同步呼叫時候的物件本身
//            public MainWindow<>4__this;

//            // 原先事件方法中，定義的本地變數 fooStr
//			private string <fooStr>5__1;

//            // 用來暫時儲存呼叫非同步方法的時候的字串值
//			private string <>s__2;

//            // 用來暫時儲存 提供等候非同步工作完成的物件
//            // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.taskawaiter(v=vs.110).aspx
//			private TaskAwaiter<string> <>u__1;

//            // 每當狀態機的狀態值有變動的時候，呼叫 MoveNext來執行下一個狀態機要執行的動作
//			void IAsyncStateMachine.MoveNext()
//            {
//            // 暫時儲存現在狀態機內的狀態值
//            int num = this.<>1__state;
//            // 當在原先方法內用了 await 關鍵字，編譯器，會加入異常事件捕捉
//            try
//            {
//                TaskAwaiter<string> taskAwaiter;
//                if (num != 0)
//                {
//                    // 一開始進入狀態機，狀態機值為-1，所以，會先進入到這裡，若狀態機值為 0 ，表示此非同步工作已經完成

//                    // 執行 GetStringAsync 方法&取得用來等候這個 Task 的 awaiter，回傳值為 提供等候非同步工作完成的物件
//                    // https://msdn.microsoft.com/zh-tw/library/system.threading.tasks.task.getawaiter(v=vs.110).aspx
//                    taskAwaiter = this.<>4__this.GetStringAsync().GetAwaiter();
//                    // 指出非同步工作是否已經完成
//                    // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.taskawaiter.iscompleted(v=vs.110).aspx
//                    if (!taskAwaiter.IsCompleted)
//                    {
//                        // 非同步工作尚未完成
//                        this.<>1__state = 0; // 設定狀態機狀態值，標明狀態值為 0，下一個週期，就不會進入到這段程式碼了
//                        this.<>u__1 = taskAwaiter;  // 用來暫時儲存 提供等候非同步工作完成的物件
//                        MainWindow.<btnDownload_Click>d__1 <btnDownload_Click>d__ = this;
//                        // 排程狀態機器以在指定的 awaiter 完成時繼續下一個動作
//                        // 也就是說，當非同步呼叫完成後，會再度回到 MoveNext() 方法重頭執行一次，不過，因為狀態值有變動了，所以，執行結果會不同
//                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, MainWindow.<btnDownload_Click>d__1> (ref taskAwaiter, ref <btnDownload_Click>d__);
//                        return;
//                    }
//                }
//                else
//                {
//                    // 因為 狀態機值為 0 ，表示此非同步工作已經完成
//                    // 取得等候非同步工作完成的物件
//                    taskAwaiter = this.<>u__1;
//                    // 設定等候非同步工作完成的物件的預設值
//                    this.<>u__1 = default(TaskAwaiter<string>);
//                    // 因為非同步工作已經完成，所以，再將狀態機值設為 -1 
//                    this.<>1__state = -1;
//                }
//                // --------------------------------------------------------
//                // 底下的程式碼，為該事件內 await 呼叫後的相關程式碼，也就是說，當完成非同步呼叫之後，會繼續回到原先地方繼續執行
//                // --------------------------------------------------------
//                // 取得 等候非同步工作完成的物件 的執行結果
//                string result = taskAwaiter.GetResult();
//                taskAwaiter = default(TaskAwaiter<string>);
//                this.<>s__2 = result;
//                this.<fooStr>5__1 = this.<>s__2;
//                this.<>s__2 = null;
//                // 這段程式法為原先非同步呼叫方法內的，並沒做任何改變
//                Console.WriteLine(this.<fooStr>5__1);
//            }
//            catch (Exception exception)
//            {
//                // await 的非同步工作，可以捕捉異常事件，並且回報給呼叫者
//                this.<>1__state = -2; 
//                this.<>t__builder.SetException(exception);
//                return;
//            }
//            this.<>1__state = -2; // 變更狀態值，表示已經完成所有的非同步工作
//            // 將方法產生器標記為成功完成。
//            this.<>t__builder.SetResult();
//        }

//        [DebuggerHidden]
//        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
//        {
//        }
//    }

//    // 這是編譯器產生出來的類別，用來處理非同步需求的狀態機
//    [CompilerGenerated]
//    private sealed class <GetStringAsync>d__2 : IAsyncStateMachine
//		{
//            // State Machine 的狀態值，表示處理到哪裡了
//			public int <>1__state;

//            // 表示非同步方法產生器，會傳回工作
//            // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.asynctaskmethodbuilder(v=vs.110).aspx
//			public AsyncTaskMethodBuilder<string> <>t__builder;

//            // 當時呼叫非同步方法的物件
//			public MainWindow <>4__this;

//            // 這個非同步方法內用到的 HttpClient 物件
//			private HttpClient <client>5__1;

//            // 原先事件方法中，定義的本地變數 result
//			private string <result>5__2;

//            // 用來暫時儲存呼叫非同步方法的時候的字串值
//			private string <>s__3;

//            // 用來暫時儲存 提供等候非同步工作完成的物件
//            // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.taskawaiter(v=vs.110).aspx
//			private TaskAwaiter<string> <>u__1;

//            // 每當狀態機的狀態值有變動的時候，呼叫 MoveNext來執行下一個狀態機要執行的動作
//			void IAsyncStateMachine.MoveNext()
//            {
//                // 暫時儲存現在狀態機內的狀態值
//                int num = this.<>1__state;
//                string result2;
//                // 當在原先方法內用了 await 關鍵字，編譯器，會加入異常事件捕捉
//               try
//               {
//                    TaskAwaiter<string> taskAwaiter;
//                    if (num != 0)
//                    {
//                        // 一開始進入狀態機，狀態機值為-1，所以，會先進入到這裡，若狀態機值為 0 ，表示此非同步工作已經完成
//                        this.<client>5__1 = new HttpClient();
//                        // 執行 GetStringAsync 方法&取得用來等候這個 Task 的 awaiter，回傳值為 提供等候非同步工作完成的物件
//                        taskAwaiter = this.<client>5__1.GetStringAsync("http://www.microsoft.com").GetAwaiter();
//                        // 指出非同步工作是否已經完成
//                        if (!taskAwaiter.IsCompleted)
//                        {
//                           // 非同步工作尚未完成
//                            this.<>1__state = 0;  // 設定狀態機狀態值，標明狀態值為 0，下一個週期，就不會進入到這段程式碼了
//                            this.<>u__1 = taskAwaiter; // 用來暫時儲存 提供等候非同步工作完成的物件
//                            MainWindow.<GetStringAsync>d__2 <GetStringAsync>d__ = this;
//                            // 排程狀態機器以在指定的 awaiter 完成時繼續下一個動作
//                            // 也就是說，當非同步呼叫完成後，會再度回到 MoveNext() 方法重頭執行一次，不過，因為狀態值有變動了，所以，執行結果會不同
//                            this.<>t__builder.AwaitUnsafeOnCompleted <TaskAwaiter<string>, MainWindow.<GetStringAsync>d__2> (ref taskAwaiter, ref <GetStringAsync>d__);
//                            return;
//                        }
//                    }
//                    else
//                    {
//                        // 因為 狀態機值為 0 ，表示此非同步工作已經完成
//                        // 取得等候非同步工作完成的物件
//                        taskAwaiter = this.<>u__1;
//                        // 設定等候非同步工作完成的物件的預設值
//                        this.<>u__1 = default(TaskAwaiter<string>);
//                        // 因為非同步工作已經完成，所以，再將狀態機值設為 -1 
//                        this.<>1__state = -1;
//                    }
//                    // --------------------------------------------------------
//                    // 底下的程式碼，為該事件內 await 呼叫後的相關程式碼，也就是說，當完成非同步呼叫之後，會繼續回到原先地方繼續執行
//                    // --------------------------------------------------------
//                    // 取得 等候非同步工作完成的物件 的執行結果
//                    string result = taskAwaiter.GetResult();
//                    taskAwaiter = default(TaskAwaiter<string>);
//                    this.<>s__3 = result;
//                    this.<result>5__2 = this.<>s__3;
//                    this.<>s__3 = null;
//                    result2 = this.<result>5__2;
//                }
//                catch (Exception exception)
//                {
//                    this.<>1__state = -2;
//                    this.<>t__builder.SetException(exception);
//                    return;
//                }
//                this.<>1__state = -2;
//                this.<>t__builder.SetResult(result2);
//         }

//    [DebuggerHidden]
//    void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
//    {
//    }
//}

//internal Button btnDownload;

//private bool _contentLoaded;

//// 這部分編譯器沒有做任何變動
//public MainWindow()
//{
//    this.InitializeComponent();
//}

//// 這裡重新改寫了 btnDownload_Click 方法
//// AsyncStateMachine 請參考 https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.asyncstatemachineattribute(v=vs.110).aspx
//[DebuggerStepThrough, AsyncStateMachine(typeof(MainWindow.<btnDownload_Click>d__1))]
//private void btnDownload_Click(object sender, RoutedEventArgs e)
//{
//    // 類別 <GetStringAsync>d__1 為編譯器產生的一個類別，其中，是運用狀態機 State Machine 觀念來處理非同步呼叫運作
//    MainWindow.<btnDownload_Click>d__1 <btnDownload_Click>d__ = new MainWindow.<btnDownload_Click>d__1();
//    // 底下的程式碼為進行該非同步呼叫的 State Machine的各種預設值初始化    // 
//    // 呼叫非同步呼叫時候的物件本身
//    < btnDownload_Click >d__.<>4__this = this;
//    // 設定該事件的 sender 物件
//    <btnDownload_Click>d__.sender = sender;
//    // 設定該事件的 RoutedEventArgs 物件
//    <btnDownload_Click>d__.e = e;
//    // 建立 AsyncTaskMethodBuilder 類別的執行個體
//    < btnDownload_Click >d__.<>t__builder = AsyncVoidMethodBuilder.Create();
//    // 該 State Machine 最初狀態值為 -1
//    <btnDownload_Click>d__.<>1__state = -1;
//    // 表示非同步方法產生器，不會傳回值。
//    // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.asyncvoidmethodbuilder(v=vs.110).aspx
//    AsyncVoidMethodBuilder<>t__builder = <btnDownload_Click>d__.<>t__builder;
//    // 開始執行具有相關聯狀態機器的產生器
//    <>t__builder.Start<MainWindow.<btnDownload_Click>d__1>(ref <btnDownload_Click>d__);
//}

//// 這個部分為要讀取微軟首頁的非同步存取方法 GetStringAsync()
//// 不過，編譯器有改寫原先的方法
//// AsyncStateMachine 請參考 https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.asyncstatemachineattribute(v=vs.110).aspx
//[DebuggerStepThrough, AsyncStateMachine(typeof(MainWindow.<GetStringAsync>d__2))]
//public Task<string> GetStringAsync()
//{
//    // 類別 <GetStringAsync>d__2 為編譯器產生的一個類別，其中，是運用狀態機 State Machine 觀念來處理非同步呼叫運作
//    MainWindow.<GetStringAsync>d__2 <GetStringAsync>d__ = new MainWindow.<GetStringAsync>d__2();
//    // 底下的程式碼為進行該非同步呼叫的 State Machine的各種預設值初始化
//    // 呼叫非同步呼叫時候的物件本身
//    <GetStringAsync>d__.<>4__this = this;
//    // 建立 AsyncTaskMethodBuilder 類別的執行個體
//    <GetStringAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
//    // 該 State Machine 最初狀態值為 -1
//    <GetStringAsync>d__.<>1__state = -1;
//    // 表示非同步方法產生器，會傳回工作。
//    // https://msdn.microsoft.com/zh-tw/library/system.runtime.compilerservices.asynctaskmethodbuilder(v=vs.110).aspx
//    AsyncTaskMethodBuilder <string> <>t__builder = <GetStringAsync>d__.<>t__builder;
//    // 開始執行具有相關聯狀態機器的產生器
//     <>t__builder.Start<MainWindow.<GetStringAsync>d__2>(ref <GetStringAsync>d__);
//    // 回傳該非同步的 Task
//    return <GetStringAsync>d__.<>t__builder.Task;
//}

//// 這部分編譯器沒有做任何變動
//[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
//public void InitializeComponent()
//{
//    bool contentLoaded = this._contentLoaded;
//    if (!contentLoaded)
//    {
//        this._contentLoaded = true;
//        Uri resourceLocator = new Uri("/AsyncAwait;component/mainwindow.xaml", UriKind.Relative);
//        Application.LoadComponent(this, resourceLocator);
//    }
//}

//[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
//void IComponentConnector.Connect(int connectionId, object target)
//{
//    if (connectionId != 1)
//    {
//        this._contentLoaded = true;
//    }
//    else
//    {
//        this.btnDownload = (Button)target;
//        this.btnDownload.Click += new RoutedEventHandler(this.btnDownload_Click);
//    }
//}
//	}
//}
