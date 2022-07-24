using Microsoft.Extensions.Configuration;

namespace _1_Entry
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(@"E:\Dotnet_a-z\Dotnet_learning_A-Z\Part2_Config_System\1_Entry\config.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot = configBuilder.Build();

            // Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
            // System.Console.WriteLine($"{proxy.Address}, {proxy.Port}");

            Config config = configRoot.Get<Config>();
            System.Console.WriteLine(config.Name);
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