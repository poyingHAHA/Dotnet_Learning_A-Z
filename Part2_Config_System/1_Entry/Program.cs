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
            configBuilder.Add(new FxConfigSource() { Path=@"E:\Dotnet_a-z\Dotnet_learning_A-Z\Part2_Config_System\1_Entry\web.config.xml" });

            IConfigurationRoot configRoot = configBuilder.Build();

            // 將Config綁定到根節點
            services.AddOptions().Configure<WebConfigDto>(e => configRoot.Bind(e));

            services.AddScoped<TestWebConfig>();

            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<TestWebConfig>();
                c.Test();
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
        public string Address { get; set; }
        public int Port { get; set; } // 由Binder自動做類型轉換
        public int[] Ids { get; set; }
    }
}