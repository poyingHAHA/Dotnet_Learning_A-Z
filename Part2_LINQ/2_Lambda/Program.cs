using System;

namespace _1_delegate
{
  class Program
  {
    static void Main(string[] args)
    {
      // 聲明匿名方法
      Action f1 = delegate(){
        System.Console.WriteLine("I am AAA");
      };
      f1();

      Action<string, int> f2 = delegate(string n, int i)
      {
        System.Console.WriteLine($"n={n}, i={i}");
      };

      f2("yzk", 18);

      Func<int, int, int> f3 = (i, j) => {
        return i+j;
      };

      System.Console.WriteLine(f3(3,4));

      Action f1_Lambda = () => System.Console.WriteLine("I am BBB");
      f1_Lambda();
    }
  }
}