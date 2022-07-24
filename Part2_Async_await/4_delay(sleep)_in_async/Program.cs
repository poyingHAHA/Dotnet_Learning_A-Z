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
          using(HttpClient client = new HttpClient())
          {
            string s1 = await client.GetStringAsync("https://www.google.com");
            s1 = s1.Substring(0, 100);
            System.Console.WriteLine(s1);

            System.Console.WriteLine("==========================");
            await Task.Delay(3000);
            // Thread.Sleep(3000);
            
            string s2 = await client.GetStringAsync("https://shopee.tw");
            s2 = s2.Substring(0, 100);
            System.Console.WriteLine(s2);

            System.Console.WriteLine("==========================");
            System.Console.WriteLine("End.");
          }
        }
    }
}