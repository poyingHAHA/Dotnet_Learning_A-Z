using Microsoft.Extensions.DependencyInjection;

namespace _2_IserviceProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            // services.AddTransient<TestServiceImpl>();
            // services.AddSingleton<TestServiceImpl>();
            services.AddScoped<ITestService, TestServiceImpl>();
            services.AddScoped<ITestService, TestServiceImpl2>();

            using(ServiceProvider sp = services.BuildServiceProvider())
            {
                IEnumerable<ITestService> tests = sp.GetServices<ITestService>();

                foreach(var test in tests)
                {
                    System.Console.WriteLine(test.GetType());
                }

                // 註冊多個抓最後一個 
                var test2 = sp.GetService<ITestService>();
                System.Console.WriteLine(test2.GetType());
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