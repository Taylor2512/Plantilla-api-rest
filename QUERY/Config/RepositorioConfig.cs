using DOMAIN.Interfaces.IExtensionR;
using DOMAIN.Interfaces.IExtensionR.Archivos;
using DOMAIN.Interfaces.IExtensionR.Financiero;
using DOMAIN.Interfaces.IExtensionR.Inventario;
using DOMAIN.Interfaces.IExtensionR.Persona;
using DOMAIN.Interfaces.IRespositorio.Archivos;
using DOMAIN.Interfaces.IRespositorio.Inventario;
using DOMAIN.Interfaces.IRespositorio.Persona;
using Microsoft.Extensions.DependencyInjection;
using QUERY.Extensions;
using QUERY.Extensions.Archivos;
using QUERY.Extensions.Financiero;
using QUERY.Extensions.Inventario;
using QUERY.Extensions.Persona;
using QUERY.Repository.Archivos;
using QUERY.Repository.Inventario;
using QUERY.Repository.Persona;
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
            //Inyeccion de Repositorios
            services.AddScoped <IUsuarioR, RepoUsuario>();
            services.AddScoped<IImagenesPersonaR, RepoImagenesPersona >();
            services.AddScoped<IImagenesProductoR, RepoImagenesProducto >();
            services.AddScoped<IProductoR, RepoProducto >();
            //Inyeccion de Extensiones
            services.AddScoped<IExtensionPersonaR, ExtensionPersonaR>();
            services.AddScoped<IExtensionFinancieroR, ExtensionFinancieroR>();
            services.AddScoped<IExtensionInventarioR, ExtensionInventarioR>();
            services.AddScoped<IExtensionArchivoR, ExtensionArchivosR>();

            //Inyeccion de dependcias de ExtensionGenerico
            services.AddScoped(typeof(IExtensionRepository<>),typeof(ExtensionRepository<>));

            await Task.CompletedTask;
        }

    }
}
