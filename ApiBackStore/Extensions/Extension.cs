using DOMAIN.Entities.Persona;
using INFRASTRUCTURE.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
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
        public static async Task IyectarAuthentication( this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["LlaveJwt"])),


                    };
                });
            Services.AddAuthorization(options =>
            {
                options.AddPolicy("EsAdmin", politica => politica.RequireClaim("EsAdmin"));
                options.AddPolicy("EsVendedor", politica => politica.RequireClaim("EsVendedor"));
                options.AddPolicy("EsComprador", politica => politica.RequireClaim("EsComprador"));
            });

            await Task.CompletedTask;
        }
    }
}
