using Microsoft.Extensions.Configuration;

namespace _1_Entry
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(@".\Dotnet_learning_A-Z\Part2_Config_System\1_Entry\config.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot = configBuilder.Build();
            string name = configRoot["name"];
            System.Console.WriteLine($"name: {name}");
            string address = configRoot.GetSection("proxy:address").Value;
            System.Console.WriteLine($"address: {address}");
        }
    }

    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; } // 由Binder自動做類型轉換
    }
}