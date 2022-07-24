using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_Entry
{
    class WebConfigDto
    {
        public ConnectStr Connl { get; set; }
        public ConnectStr ConnTest { get; set; }
        public Config Config { get; set; }
    }

    class ConnectStr
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}