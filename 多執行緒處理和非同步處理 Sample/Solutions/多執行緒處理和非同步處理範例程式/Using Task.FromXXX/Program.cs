using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Using_Task.FromXXX
{
    class Program
    {
        public static void Main()
        {
            List<string> args = new List<string>()
            {
               //Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\.."),
               Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\ILSpy"),
            };

            List<Task<long>> tasks = new List<Task<long>>();
            for (int ctr = 0; ctr < args.Count; ctr++)
                tasks.Add(GetFileLengthsAsync(args[ctr]));

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            // Ignore exceptions here.
            catch (AggregateException) { }

            for (int ctr = 0; ctr < tasks.Count; ctr++)
            {
                if (tasks[ctr].Status == TaskStatus.Faulted)
                    Console.WriteLine("{0} does not exist", args[ctr + 1]);
                else
                    Console.WriteLine("{0:N0} bytes in files in '{1}'",
                                      tasks[ctr].Result, args[ctr]);
            }
            Console.ReadKey();
        }

        private static Task<long> GetFileLengthsAsync(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                return Task.FromException<long>(
                            new DirectoryNotFoundException("Invalid directory name."));
            }
            else
            {
                string[] files = Directory.GetFiles(filePath);
                if (filePath.Length == 0)
                    return Task.FromResult(0L);
                else
                    return Task.Run(() =>
                    {
                        long total = 0;
                        #region 使用平行處理
                        //Parallel.ForEach(files, (fileName) =>
                        //{
                        //    var fs = new FileStream(fileName, FileMode.Open,
                        //                            FileAccess.Read, FileShare.ReadWrite,
                        //                            256, true);
                        //    long length = fs.Length;
                        //    total = Interlocked.Add(ref total, length);
                        //    fs.Close();
                        //});
                        #endregion

                        #region 使用同步處理
                        foreach (var fileName in files)
                        {
                            var fs = new FileStream(fileName, FileMode.Open,
                                                    FileAccess.Read, FileShare.ReadWrite,
                                                    256, true);
                            long length = fs.Length;
                            total = Interlocked.Add(ref total, length);
                            fs.Close();
                        }
                        #endregion
                        return total;
                    });
            }
        }
    }
}
