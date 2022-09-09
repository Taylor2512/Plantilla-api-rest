using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Config
{
    public static class RepositorioConfig
    {
        public static async Task InyectarRepositorios(this IServiceCollection services)
        {
            await Task.CompletedTask;
        }

    }
}
