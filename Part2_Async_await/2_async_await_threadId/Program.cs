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
            // 線程屬於託管資源所以是managed
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                sb.Append("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            
            await File.WriteAllTextAsync(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\2_async_await_threadId\2.txt", sb.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 1000; i++)
            {
                sb.Append("YYYYYYYYYYYYYYYYYYyyyyyyyyyyyyyyyyyyyyyyyy");
            }
            await File.WriteAllTextAsync(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\2_async_await_threadId\2.txt", sb.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
