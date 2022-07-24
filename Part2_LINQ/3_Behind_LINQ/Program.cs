using System;

namespace _3_Behind_LINQ
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] {3,5,12,133,12,55,6,9};
      IEnumerable<int> result = nums.Where(a => a>10);
      foreach (var item in result)
      {
        System.Console.WriteLine(item);
      }

      System.Console.WriteLine("========================");

      // 調用自己的LINQ
      IEnumerable<int> mynums = nums.MyWhere(a => a > 20);
      foreach (var item in mynums)
      {
        System.Console.WriteLine(item);
      }

    }

  }

  public static class MyExtension
  {
    public static IEnumerable<int> MyWhere(this IEnumerable<int> items, Func<int, bool> fn)
    {
      List<int> result = new List<int>();
      foreach (var item in items)
      {
        if(fn(item))
        {
          result.Add(item);
        }
      }
      return result;
    }
  }
}