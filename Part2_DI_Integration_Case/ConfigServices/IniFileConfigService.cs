using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class IniFileConfigService : IConfigService
    {
        public string FilePath { get; set; }
        public string GetValue(string name)
        {
            var kv = File.ReadAllLines(FilePath).Select(s => s.Split('=')).Select(arr => new {Name=arr[0], Value=arr[1]})
                .SingleOrDefault(kv => kv.Name == name);
            
            if(kv != null)
            {
                return kv.Value;
            }
            else
            {
                return null;
            }
        }
    }
}