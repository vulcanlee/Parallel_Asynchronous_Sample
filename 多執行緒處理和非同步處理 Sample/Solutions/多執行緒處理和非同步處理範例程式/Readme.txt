這個資料夾內的四個專案，分別描述了早期要寫出非同步的程式碼，
透過 Asynchronous Programming Patterns 方式，
所做出的程式會有著許多問題與缺陷

001 Blocking Application Execution Using an AsyncWaitHandle
這個範例使用了 AsyncWaitHandle 來等候非同步工作執行完成，這也造成了呼叫端的 Thread 會被 Block

002 Blocking Application Execution by Ending Async Operation
以結束非同步作業的方式封鎖應用程式執行

003 Polling for the Status of an Asynchronous Operation
使用輪詢非同步作業的狀態

004 Using AsyncCallback Delegate to End Asynchronous Operation
使用 AsyncCallback 委派，得知何時結束非同步作業
