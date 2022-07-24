using System;

namespace _4_Ordinary_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "Jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "Jim", Age = 22, Gender = true, Salary = 6000 });
            list.Add(new Employee { Id = 3, Name = "Lily", Age = 33, Gender = false, Salary = 7000 });
            list.Add(new Employee { Id = 4, Name = "Lucy", Age = 55, Gender = false, Salary = 8000 });
            list.Add(new Employee { Id = 5, Name = "Kimi", Age = 55, Gender = true, Salary = 9000 });
            list.Add(new Employee { Id = 6, Name = "Nacy", Age = 66, Gender = false, Salary = 10000 });
            list.Add(new Employee { Id = 7, Name = "Zack", Age = 77, Gender = true, Salary = 11000 });
            list.Add(new Employee { Id = 8, Name = "Edwin", Age = 88, Gender = true, Salary = 12000 });

            // 1. 常用LINQ: Where、 Any、 Count
            var people = list.Where(x => x.Age > 40);
            foreach (var person in people)
            {
                System.Console.WriteLine(person);
            }

            System.Console.WriteLine("大於50歲人數: " + list.Count(a => a.Age > 50));
            System.Console.WriteLine("是否有人薪資大於11000: " + list.Any(a => a.Salary > 11000));

            // 2. 獲取一條數據LINQ: Single、SingleOrDefault、 First、 FirstOrDefault
            System.Console.WriteLine("==========================================");
            Employee p1 = list.Where(e => e.Name == "Jerry").Single();
            System.Console.WriteLine(p1);

            System.Console.WriteLine(list.Single(a => a.Name == "Edwin"));
            System.Console.WriteLine(list.SingleOrDefault(e => e.Name == "Jean", p1));

            // 2. 對數據排序
            System.Console.WriteLine("=========================================");
            // IEnumerable<Employee> items = list.OrderBy(e => e.Age);
            // IEnumerable<Employee> items = list.OrderByDescending(e => e.Age);
            IEnumerable<Employee> items = list.OrderByDescending(e => e.Name[e.Name.Length - 1]);
            foreach (Employee e in items)
            {
                System.Console.WriteLine(e);
            }

            int[] nums = new int[] { 2, 4, 1, 3, 1, 2, 5, 5, 1, 7, 8 };
            var num2 = nums.OrderBy(i => i);
            foreach (int i in num2)
            {
                System.Console.WriteLine(i);
            }
            
            // 2. OrderBy 加 ThenBy
            System.Console.WriteLine("========================================");
            var employees = list.OrderBy(i => i.Age).ThenBy(i => i.Salary);
            foreach (Employee i in employees)
            {
                System.Console.WriteLine(i);
            }

            // 3. GroupBy
            System.Console.WriteLine("========================================");
            IEnumerable<IGrouping<int, Employee>> group = list.GroupBy(i => i.Age);
            foreach (var g in group)
            {
                System.Console.WriteLine(g.Key);
                foreach (Employee i in g)
                {
                    System.Console.WriteLine(i);
                }
                System.Console.WriteLine("*************");
            }

            // 4. Select投影
            System.Console.WriteLine("========================================");
            var test1 = list.Select(i => i.Age.ToString() +" "+ i.Name);
            foreach (var test in test1)
            {
                System.Console.WriteLine(test);
            }

            System.Console.WriteLine("========================================");
            var test2 = list.Where(i => i.Salary > 6000).Select(i => i.Name);
            foreach(var test in test2)
            {
                System.Console.WriteLine(test);
            }

            // 5. 鍊式調用
            System.Console.WriteLine("========================================");
            List<Employee> list4 = new List<Employee>();
            list4.Add(new Employee { Id = 1, Name = "Jerry", Age = 22, Gender = true, Salary = 5000 });
            list4.Add(new Employee { Id = 2, Name = "Jim", Age = 22, Gender = true, Salary = 6000 });
            list4.Add(new Employee { Id = 3, Name = "Lily", Age = 22, Gender = false, Salary = 7000 });
            list4.Add(new Employee { Id = 4, Name = "Lucy", Age = 22, Gender = false, Salary = 8000 });
            list4.Add(new Employee { Id = 5, Name = "Kimi", Age = 33, Gender = true, Salary = 9000 });
            list4.Add(new Employee { Id = 6, Name = "Nacy", Age = 33, Gender = false, Salary = 10000 });
            list4.Add(new Employee { Id = 7, Name = "Zack", Age = 33, Gender = true, Salary = 11000 });
            list4.Add(new Employee { Id = 8, Name = "Edwin", Age = 33, Gender = true, Salary = 12000 });

            var list3 = list4.GroupBy(x => x.Age).Select(g => new{Age=g.Key, Count=g.Count(), Average=g.Average(x => x.Salary)});
            foreach (var g2 in list3)
            {
                System.Console.WriteLine(g2.Age+" "+g2.Count+" "+g2.Average);
            }

        }

    }

    class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Age={Age}, Gender={Gender}, Salary={Salary}";
        }
    }

}