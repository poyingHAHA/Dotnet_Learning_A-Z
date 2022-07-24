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
        }
    }
}