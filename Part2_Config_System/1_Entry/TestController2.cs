using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace _1_Entry
{
    class TestController2
    {
        private readonly IOptionsSnapshot<Proxy> _optProxy;
        

        public TestController2(IOptionsSnapshot<Proxy> optProxy)
        {
            _optProxy = optProxy;
        }

        public void Test()
        {
            System.Console.WriteLine(_optProxy.Value.Address);
        }
    }
}