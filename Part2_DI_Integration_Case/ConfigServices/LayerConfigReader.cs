using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class LayerConfigReader : IConfigReader
    {
        private readonly IEnumerable<IConfigService> services;

        public LayerConfigReader(IEnumerable<IConfigService> services)
        {
            this.services = services;
        }

        public string GetValue(string name)
        {
            string value = null;
            foreach (var service in services)
            {
                // 所有都走一遍，最後一個不為null就是最終的值
                string newValue = service.GetValue(name);
                if(newValue != null)
                {
                    value = newValue;
                }
            }
            return value;
        }
    }
}