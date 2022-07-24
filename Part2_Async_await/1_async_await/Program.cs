using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace _1_async_await
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
        }

        // 介紹async、await原理
        public async static Task GetHtmlAsync(string url)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string html = await httpClient.GetStringAsync(url);
                Console.WriteLine(html);
            }

            string txt = "hello Edwin";
            string filename = @"E:\Dotnet_a-z\Dotnet_learning_A-Z\1_async_await\text.txt";
            await File.WriteAllTextAsync(filename, txt);
            Console.WriteLine("Write success");
            string s = await File.ReadAllTextAsync(filename);
            Console.WriteLine("Read success");
        }

    }
}
