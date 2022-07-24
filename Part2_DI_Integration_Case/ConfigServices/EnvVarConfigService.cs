using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class EnvVarConfigService : IConfigService
    {
        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}