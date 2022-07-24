using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace _1_Entry
{
    class TestController
    {
        private readonly IOptionsSnapshot<Config> _optConfig;

        public TestController(IOptionsSnapshot<Config> optConfig)
        {
            _optConfig = optConfig;
        }

        public void Test()
        {
            System.Console.WriteLine(_optConfig.Value.Age);
            System.Console.WriteLine("*****************");
            System.Console.WriteLine(_optConfig.Value.Name);
            System.Console.WriteLine(_optConfig.Value.Proxy.Address);
            System.Console.WriteLine(_optConfig.Value.Proxy.Port);
            System.Console.WriteLine(string.Join("," ,_optConfig.Value.Proxy.Ids));
        }
    }
}