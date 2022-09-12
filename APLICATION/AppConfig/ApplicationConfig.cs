using APLICATION.AppServices.Inventario;
using APLICATION.AppServices.Persona;
using APLICATION.AppServicesExternal.Azure;
using APLICATION.ExtensionS;
using APLICATION.ExtensionS.Archivos;
using APLICATION.ExtensionS.Financiero;
using APLICATION.ExtensionS.Inventario;
using APLICATION.ExtensionS.Persona;
using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IExtensionS.Archivos;
using DOMAIN.Interfaces.IExtensionS.Financiero;
using DOMAIN.Interfaces.IExtensionS.Inventario;
using DOMAIN.Interfaces.IExtensionS.Persona;
using DOMAIN.Interfaces.IServices.Inventario;
using DOMAIN.Interfaces.IServices.Persona;
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
            services.AddScoped<IServicioUsuarios, UsuarioServices>();

            // inventarion dependencias
            services.AddScoped<IProductoServices, ProductoServices> ();
            // dependencias externas
            services.AddScoped<IAzureStorageService, AzureStorageService>();

            ///// Servicios De Extension

            services.AddScoped<IExtensionArchivoS, ExtensionArchivoS>();
            services.AddScoped<IExtensionInventarioS, ExtensionInventarioS>();
            services.AddScoped<IExtensionFinancieroS, ExtensionFinancieroS>();
            services.AddScoped<IExtensionPersonaS, ExtensionPersonaS>();
            //inyecciones de Extensiones Genericas

            services.AddScoped (typeof(IExtensionServices<>),typeof( ExtensionServices<>));

            // Inyeccion de automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            await Task.CompletedTask;
        }
    }
}
