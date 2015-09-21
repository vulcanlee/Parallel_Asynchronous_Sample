分享資訊
------------
* 分享時間：
* 分享主題：多執行緒處理和非同步處理
* 講者姓名：李進興 Vulcan
* 講題摘要：本次分享將會著重於使用 .Net C# 的多執行緒開發與非同步的應用說明，首先，會說明作業系統中的基本相關概念，接著會透過許多實際範例，講解多執行緒與非同步程式開發的方法與注意事項
* 講題大綱：
  *Thread
  *Asynchronous Programming Patterns
  *Parallel class
  *Concurrent collections 
* 範例程式清單
  *[APM EAP TAP] C# 內提供的三中非同步撰寫方式
  *APM Asynchronous Programming Model
  *EAP Event-based Asynchronous Pattern
  *TAP Task-based Asynchronous Pattern

  *[Asynchronous Programming Patterns] 各種非同步處理的情境
  *001 Blocking Application Execution by Ending Async Operation
  *002 Blocking Application Execution Using an AsyncWaitHandle
  *003 Polling for the Status of an Asynchronous Operation
  *004 Using AsyncCallback Delegate to End Asynchronous Operation

  *[Concurrent Collections] 平行處理 Multi-Thread的時候，具有 Thread Saved的 Collection操作範例
  *001 Uses Dictionary
  *002 Uses ConcurrentDictionary
  *003 TryUpdate ConcurrentDictionary

  *[Parallel]  大量資料的平行處理範例
  *Using Parallel.For
  *Using Parallel.Foreach
  *Using Parallel.Break

  *[Task] TPL 內的 Task 應用與操作說明，可以當作用於簡易平行處理的作法
  *001 async and await
  *001 Starting a new Task
  *002 Starting a new Task using TaskFactory
  *003 Using a Task that returns a value
  *004 Starting Multi Task
  *005 Adding a continuation
  *006 Scheduling different continuation tasks
  *007 Using Task.WaitAll
  *008 Using Task.WaitAny
  *009 Using ConfigureAwait
  *010 Multiple Web Requests in Parallel by Using Async and Await
  *011 Using Task.FromXXX

  *[Thread] C# 內的基本操作與注意事項
  *001 Creating a thread with the Thread class
  *002 Using a background thread
  *003 Using the ParameterizedThreadStart
  *004 Stopping a thread
  *005 Using the ThreadStaticAttribute
  *006 Using ThreadLocal
  *007 Queuing some work to the thread pool
  *008 Race Condition
  *008 Race Condition2
  *009 Race Condition using lock keyword

* 相關連結：
  * http://www.amazon.com/Exam-Ref-70-483-Programming-MCSD/dp/0735676828
  * http://www.amazon.com/CLR-via-4th-Developer-Reference/dp/0735667454/ref=sr_1_1?s=books&ie=UTF8&qid=1442807191&sr=1-1&keywords=Microsoft.Press.CLR.via.Csharp
  * http://www.amazon.com/Asynchronous-Programming-NET-Richard-Blewett/dp/1430259205/ref=sr_1_1?s=books&ie=UTF8&qid=1442807236&sr=1-1&keywords=async+await
  * http://resources.infosecinstitute.com/multithreading/
  * https://www.youtube.com/watch?v=RhLLxew4-TY&list=PLhq7kqloVlM897pJ9TdVHVRo5stL_LlMu
  * http://arthurmvc.blogspot.tw/2013/09/tpltask-parallel-language.html
  * http://www.filipekberg.se/2013/01/16/what-does-async-await-generate/
  * http://blogs.msdn.com/b/pfxteam/archive/2012/08/02/processing-tasks-as-they-complete.aspx
  * https://msdn.microsoft.com/en-us/library/dd460693(v=vs.110).aspx
  * https://en.wikipedia.org/wiki/Thread_(computing)
  * https://en.wikipedia.org/wiki/Context_switch
  * http://prasadhonrao.com/how-to-avoid-race-condition-in-csharp/
  * http://prasadhonrao.com/how-to-avoid-race-condition-in-csharp/
  * https://www.google.com.tw/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0CB0QFjAAahUKEwjjydfinYfIAhXMkZQKHREVAuM&url=http%3A%2F%2Fwww.albahari.info%2Fthreading%2Fthreading.pdf&usg=AFQjCNE8s81_81qYKoz9uKBL5qWkd7YzZw&sig2=-gm1oxe2QsqLVi9d99DW0Q
  * https://en.wikipedia.org/wiki/Thread_safety
  * https://msdn.microsoft.com/zh-tw/library/hyz69czz(v=vs.110).aspx
  * https://msdn.microsoft.com/zh-tw/library/system.threading.thread(v=vs.110).aspx
  * https://msdn.microsoft.com/en-us/library/jj152938(v=vs.110).aspx
  * https://msdn.microsoft.com/en-us/library/dd997373(v=vs.110).aspx
  * 

注意事項
------------

* 請務必上傳可供編輯修改的簡報原始檔
  * 若為 Keynote 格式，請額外上傳轉換過的 PPTX 檔案
* 請將簡報中會用到的一些參考連結都整理到 **相關連結** 的地方
  * 若有一些其他相關文章連結，也請盡量提供上來



