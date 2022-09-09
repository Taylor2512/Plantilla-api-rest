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
            await Task.CompletedTask;
        }
    }
}
