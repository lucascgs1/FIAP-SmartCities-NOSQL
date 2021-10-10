using MongoDB.Driver;
using PokeM.Api.Models;
using PokeM.Api.Models.Documents;
using System.Collections.Generic;
using System.Linq;

namespace PokeM.Api.Services
{
    public class VeiculoService
    {
        private readonly IMongoCollection<Veiculo> _veiculos;

        public VeiculoService(IPokeDatabaseSettings settings)
        {
            var client = new MongoClient(MongoClientSettings.FromConnectionString(settings.ConnectionString));
            var database = client.GetDatabase(settings.DatabaseName);

            _veiculos = database.GetCollection<Veiculo>(settings.VeiculoCollectionName);
        }

        /// <summary>
        /// lista todos os veiculos cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Veiculo> Get() => _veiculos.Find(book => true).ToList();

        /// <summary>
        /// obtem dados do veiculo apartir do id
        /// </summary>
        /// <param name="id">codigo do veiculo</param>
        /// <returns></returns>
        public Veiculo Get(string id) => _veiculos.Find(book => book.Id == id).FirstOrDefault();

        /// <summary>
        /// cria um novo veiculo
        /// </summary>
        /// <param name="usuario">dados do veiculo</param>
        /// <returns></returns>
        public Veiculo Create(Veiculo veiculo)
        {
            _veiculos.InsertOne(veiculo);
            return veiculo;
        }

        /// <summary>
        /// atualiza um objeto apartir do veiculo e id
        /// </summary>
        /// <param name="id">codigo do veiculo</param>
        /// <param name="usuario">veiculo</param>
        public void Update(string id, Veiculo usuario) => _veiculos.ReplaceOne(book => book.Id == id, usuario);

        /// <summary>
        /// deletar veiculo apartir de objeto
        /// </summary>
        /// <param name="veiculo">veiculo</param>
        public void Remove(Veiculo veiculo) => _veiculos.DeleteOne(book => book.Id == veiculo.Id);

        /// <summary>
        /// deleta um veiculo apartir do id
        /// </summary>
        /// <param name="id">id do veiculo</param>
        public void Remove(string id) => _veiculos.DeleteOne(book => book.Id == id);
    }
}