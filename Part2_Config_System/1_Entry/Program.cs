using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _1_Entry
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\Part2_Config_System\1_Entry\config.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot = configBuilder.Build();

            // 將Config綁定到根節點
            services.AddOptions()
                .Configure<Config>(e => configRoot.Bind(e))
                .Configure<Proxy>(e => configRoot.GetSection("proxy").Bind(e));

            services.AddScoped<TestController>();
            services.AddScoped<TestController2>();

            using(var sp = services.BuildServiceProvider())
            {
                while(true)
                {
                    // 手動開啟新scope來體驗IOptionsSnapshot在不同scope下的對應於config.json的改變
                    using (var scope = sp.CreateScope())
                    {
                        var c = scope.ServiceProvider.GetRequiredService<TestController>();
                        c.Test();
                        System.Console.WriteLine("改一下age");
                        Console.ReadKey();
                        c.Test();
                        var c2 = scope.ServiceProvider.GetRequiredService<TestController2>();
                        c2.Test();
                    }

                    System.Console.WriteLine("Click To Continue");
                    Console.ReadKey();
                }
            }
        }
    }

    class Config
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Proxy? Proxy { get; set; }
    }

    class Proxy
    {
        public string? Address { get; set; }
        public int Port { get; set; } // 由Binder自動做類型轉換
    }
}