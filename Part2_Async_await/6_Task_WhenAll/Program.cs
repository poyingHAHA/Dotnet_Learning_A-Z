using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_async_await_threadId
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
          // Task<string> t1 = File.ReadAllTextAsync(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\2_async_await_threadId\2.txt");
          // Task<string> t2 = File.ReadAllTextAsync(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\2_async_await_threadId\2.txt");
          // Task<string> t3 = File.ReadAllTextAsync(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\2_async_await_threadId\2.txt");

          // string[] strs = await Task.WhenAll(t1, t2, t3);
          // string s1 = strs[0];
          // string s2 = strs[1];
          // string s3 = strs[2];

          // System.Console.WriteLine(s1);
          // System.Console.WriteLine(s2);
          // System.Console.WriteLine(s3);
          
          // 計算文件夾中所有文件長度總和
          string[] files = Directory.GetFiles(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\6_Task_WhenAll");
          Task<int>[] countTasks = new Task<int>[files.Length];

          System.Console.WriteLine(files.Length);
          
          for(int i=0; i<files.Length; i++)
          {
            string filename = files[i];
            Task<int> t = CountFileChar(filename);
            countTasks[i] = t;
          }
          int[] counts = await Task.WhenAll(countTasks);
          int c = counts.Sum();
          System.Console.WriteLine(c);
        }

        static async Task<int> CountFileChar(string filename)
        {
          string s = await File.ReadAllTextAsync(filename);
          return s.Length;
        }
    }
}