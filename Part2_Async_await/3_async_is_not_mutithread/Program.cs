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
      Console.WriteLine("Before: " + Thread.CurrentThread.ManagedThreadId);
      double r = await CalcAsync(50000);
      System.Console.WriteLine($"r={r}");
      Console.WriteLine("After: " + Thread.CurrentThread.ManagedThreadId);
    }

    public static async Task<double> CalcAsync(int n)
    {
      Console.WriteLine("CalcAsync: " + Thread.CurrentThread.ManagedThreadId);
      double result = 0;

      Random rand = new Random();

      for (var i = 0; i < n * n; i++)
      {
        result += rand.NextDouble();
      }

      return result;
    }
  }
}