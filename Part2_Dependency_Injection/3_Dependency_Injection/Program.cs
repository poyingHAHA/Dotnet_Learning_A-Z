using Microsoft.Extensions.DependencyInjection;

namespace _3_Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            // 存放註冊的服務
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILog, LogImpl>();
            services.AddScoped<IStorage, StorageImpl>();
            services.AddScoped<IConfig, ConfigImpl>();

            using(var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<Controller>();
                c.Test();
            }
        }
    }

    class Controller
    {
        private readonly ILog _log;
        private readonly IStorage _storage;

        public Controller(ILog log, IStorage storage)
        {
            _log = log;
            _storage = storage;
        }

        public void Test()
        {
            _log.Log("Start.....");
            _storage.Save("asdadsasdasdasdwq", "1.txt");
            _log.Log("Done......");
        }
    }

    interface ILog
    {
        public void Log(string msg);
    }

    class LogImpl:ILog
    {
        public void Log(string msg)
        {
            System.Console.WriteLine($"日誌: {msg}");
        }
    }

    interface IConfig
    {
        public string GetValue(string name);
    }

    class ConfigImpl: IConfig
    {
        public string GetValue(string name)
        {
            return "Hello";
        }
    }

    interface IStorage
    {   
        public void Save(string content, string naem);
    }

    class StorageImpl : IStorage
    {   
        private readonly IConfig config;
        public StorageImpl(IConfig config)
        {
            this.config = config;
        }

        public void Save(string content, string name)
        {
            string server = config.GetValue("server");
            System.Console.WriteLine($"Send file {name} to sever {server} with content {content}");
        }
    }
}