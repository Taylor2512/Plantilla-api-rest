using DOMAIN.Entities.Persona;
using INFRASTRUCTURE.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

namespace ApiBackStore.Extensions
{
    public static class Extension
    {
        public static async Task InyectarContexto(this WebApplicationBuilder builder)
        {

           

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultdatabase"));
                options.EnableSensitiveDataLogging(true);

            });
            builder.Services.AddIdentity<Usuarios, Rol>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



        }
        public static async Task InyectarFormatoJSon(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

            await Task.CompletedTask;
        }
        public static async Task InyectJsonnAppeSettings(this WebApplicationBuilder builder)
        {
          //  await builder.Services.InyectJsonnAppeSettings(builder.Configuration);

        }
    }
}
