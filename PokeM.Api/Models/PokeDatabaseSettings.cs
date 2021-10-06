using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeM.Api.Models
{
    public class PokeDatabaseSettings : IPokeDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UsuarioCollectionName { get; set; }
        public string ParadaCollectionName { get; set; }
        public string VeiculoCollectionName { get; set; }
    }

    public interface IPokeDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UsuarioCollectionName { get; set; }
        string ParadaCollectionName { get; set; }
        string VeiculoCollectionName { get; set; }
    }
}
