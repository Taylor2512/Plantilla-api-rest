using APLICATION.AppConfig;
using QUERY.Config;

namespace ApiBackStore.Extensions
{
    public static class Dependencies
    {
        /// <summary>
        /// Se realiza una extension de las dependencias en la cual se inserta los contextos servicios Repositorios 
        /// y configuraciones que actuaran durante toda la vida  de la aplicacion
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static async Task InyectarDependencies(this WebApplicationBuilder builder)
        {
            await builder.InyectarContexto();
            await builder.Services.InyectarServicios();
            await builder.Services.InyectarRepositorios();
            await builder.InyectJsonnAppeSettings();

            await Task.CompletedTask;
        }
    }
}
