using Microsoft.Extensions.DependencyInjection;

namespace _1_IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            // services.AddTransient<TestServiceImpl>();
            // services.AddSingleton<TestServiceImpl>();
            services.AddScoped<TestServiceImpl>();
            using (ServiceProvider sp = services.BuildServiceProvider())
            {

                TestServiceImpl t = sp.GetService<TestServiceImpl>();
                t.Name = "Edwin";
                t.SayHi();

                TestServiceImpl t1 = sp.GetService<TestServiceImpl>();
                System.Console.WriteLine(Object.ReferenceEquals(t, t1));
                t1.Name = "Lily";
                t1.SayHi();
                t.SayHi();

                using (IServiceScope scope1 = sp.CreateScope())
                {
                    // 在scope中獲取Scope相關的對象
                    TestServiceImpl t2 = scope1.ServiceProvider.GetService<TestServiceImpl>();
                    t2.Name = "Lucy from scope1";
                    t2.SayHi();
                    t.SayHi();
                }

                using (IServiceScope scope2 = sp.CreateScope())
                {
                    // 在scope中獲取Scope相關的對象
                    TestServiceImpl t3 = scope2.ServiceProvider.GetService<TestServiceImpl>();
                    t3.Name = "Lucy from scope2";
                    t3.SayHi();
                }
            }
        }
    }

    interface ITestService
    {
        public string Name { get; set; }
        public void SayHi();
    }

    class TestServiceImpl : ITestService
    {
        public string Name { get; set; }
        public void SayHi()
        {
            System.Console.WriteLine($"Hi, I'm {Name}.");
        }
    }

    class TestServiceImpl2 : ITestService
    {
        public string Name { get; set; }
        public void SayHi()
        {
            System.Console.WriteLine($"嗨, 我是 {Name}.");
        }
    }
}