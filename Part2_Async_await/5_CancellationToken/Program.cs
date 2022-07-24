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
          CancellationTokenSource cts = new CancellationTokenSource();
          cts.CancelAfter(5000); // 5s後還沒結束就終止請求
          await DownloadAsync("https://google.com", 100, cts.Token); 
        }

        static async Task DownloadAsync(string url, int n)
        {
          using(HttpClient client = new HttpClient())
          {
            for(int i=0; i<n; i++)
            {
              string html = await client.GetStringAsync(url);
              System.Console.WriteLine($"{DateTime.Now}: {html.Substring(0,100)}");
            }
          }
        }

        static async Task DownloadAsync(string url, int n, CancellationToken cancellationToken)
        {
          using(HttpClient client = new HttpClient())
          {
            for(int i=0; i<n; i++)
            {
              string html = await client.GetStringAsync(url);
              System.Console.WriteLine($"{DateTime.Now}: {html.Substring(0,100)}");
              
              if(cancellationToken.IsCancellationRequested)
              {
                System.Console.WriteLine("請求被取消");
                break;
              }
            }
          }
        }
    }
}