using APLICATION.AppServicesExternal.Azure;
using DOMAIN.Interfaces.IServicesExternals.Azure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.AppConfig
{
    public static class ApplicationConfig
    {
        public static async Task InyectarServicios(this IServiceCollection services)
        {
            services.AddScoped<IAzureStorageService, AzureStorageService>();
            await Task.CompletedTask;
        }
    }
}
