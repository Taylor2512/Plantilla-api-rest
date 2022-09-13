using ApiBackStore.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ApiBackStore.Config
{
    public static class Startup
    {
        /// <summary>
        /// Metodo de inizializacionde la aplicacion
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<WebApplication> Inizializar(this string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            await builder.ConfigureServices();
            var app = builder.Build();
            app = await app.MillwareServices();
            await Task.CompletedTask;
            return app;
        }
        /// <summary>
        /// Configuraciones de servicios 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static async Task ConfigureServices(this WebApplicationBuilder builder)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            await builder.InyectarDependencies();
            await builder.InyectarFormatoJSon();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("TODO", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "Api de Integracion de Contifico",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // using System.Reflection;
              /*  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, APLICATION.Constants.Parameters.xmlAplication));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, DOMAIN.Constans.Parameters.xmlDomain));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, INFRASTRUCTURE.Constanst.Parameters.xmlInfrastructure));
         */  });

            await Task.CompletedTask;
        }
        /// <summary>
        /// Configuraciones de Millware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>

        public static async Task<WebApplication> MillwareServices(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("TODO");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            await app.RunAsync();
            await Task.CompletedTask;
            return app;

        }

    }
}
