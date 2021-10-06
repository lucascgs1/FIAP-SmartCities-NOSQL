using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeM.Api.Configuration
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "Pokedevs",
                            Version = "v1",
                            Description = "Api criada para fiap SmartCitys",
                            Contact = new OpenApiContact
                            {
                                Name = "PokeDevs",
                                Url = new Uri("https://github.com/lucascgs1/Pokedevs")
                            }
                        });

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                });
        }


        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeM.Api v1");
                //c.RoutePrefix = string.Empty;
            });
        }
    }
}
