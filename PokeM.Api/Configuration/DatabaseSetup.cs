using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PokeM.Api.Models;
using PokeM.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeM.Api.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<PokeDatabaseSettings>(configuration.GetSection(nameof(PokeDatabaseSettings)));

            services.AddSingleton<IPokeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<PokeDatabaseSettings>>().Value);

            services.AddSingleton<ParadaService>();
            services.AddSingleton<UsuarioService>();
            services.AddSingleton<VeiculoService>();
        }
    }
}
