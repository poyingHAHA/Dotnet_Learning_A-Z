using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigServices
{
    public interface IConfigService
    {
        public string GetValue(string name);
    }
}