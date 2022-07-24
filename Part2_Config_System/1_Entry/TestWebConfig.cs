using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace _1_Entry
{
    class TestWebConfig
    {
        private IOptionsSnapshot<WebConfigDto> WcOpt;

        public TestWebConfig(IOptionsSnapshot<WebConfigDto> WcOpt)
        {
            this.WcOpt = WcOpt;
        }

        public void Test()
        {
            var wc = WcOpt.Value;
            System.Console.WriteLine(wc.Connl.ConnectionString);
            System.Console.WriteLine(wc.Config.Age);
            System.Console.WriteLine(wc.Config.Proxy.Address);
        }
    }
}