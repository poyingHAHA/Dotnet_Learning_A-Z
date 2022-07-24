using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LayerConfigExtensions
    {
        public static void AddLayeredConfig(this IServiceCollection services)
        {
            services.AddScoped<IConfigReader, LayerConfigReader>();
        }
    }
}