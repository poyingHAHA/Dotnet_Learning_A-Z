using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace _1_Entry
{
    class FxConfigProvider : FileConfigurationProvider
    {
        public FxConfigProvider(FxConfigSource src):base(src)
        {
            
        }

        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            var connsNodes = xmlDoc.SelectNodes("/Configuration/connectionStrings/add");
            foreach (var connsNode in connsNodes.Cast<XmlNode>())
            {
                string name = connsNode.Attributes["name"].Value;
                string connectionString = connsNode.Attributes["connectionString"].Value;

                data[$"{name}:connectionString"] = connectionString;

                var attProviderName = connsNode.Attributes["providerName"];
                if(attProviderName != null)
                {
                    data[$"{name}:providerName"] = attProviderName.Value;
                }

            }

            var appsNodes = xmlDoc.SelectNodes("/Configuration/connectionStrings/add");
            foreach (var appsNode in appsNodes.Cast<XmlNode>())
            {
                string key = appsNode.Attributes["key"].Value;
                key = key.Replace(".",":");
                string value = appsNode.Attributes["value"].Value;
                data[key] = value;
            }

            this.Data = data;
        }
    }
}