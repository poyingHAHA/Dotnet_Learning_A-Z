using System;

namespace _1_delegate
{
  class Program
  {
    static void Main(string[] args)
    {
      D1 d1 = F1;
      d1();

      // D1 d2 = Add;
      D2 d2 = Add;
      int r1 = d2(3,4);

      Func<int, int, int> f1 = Add;
      int r2 = f1(1,2);
      System.Console.WriteLine(r2);
    }

    static void F1()
    {
      System.Console.WriteLine("I am F1");
    }

    static int Add(int x, int y)
    {
      return x+y;
    }
  }


  delegate void D1();

  delegate int D2(int x, int y);
}