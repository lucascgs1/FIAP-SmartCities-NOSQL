using MongoDB.Driver;
using PokeM.Api.Models;
using PokeM.Api.Models.Documents;
using System.Collections.Generic;
using System.Linq;

namespace PokeM.Api.Services
{
    public class ParadaService
    {
        private readonly IMongoCollection<Parada> _paradas;

        public ParadaService(IPokeDatabaseSettings settings)
        {
            var client = new MongoClient(MongoClientSettings.FromConnectionString(settings.ConnectionString));
            var database = client.GetDatabase(settings.DatabaseName);

            _paradas = database.GetCollection<Parada>(settings.ParadaCollectionName);
        }

        /// <summary>
        /// lista todos os paradas cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Parada> Get() => _paradas.Find(book => true).ToList();

        /// <summary>
        /// obtem dados do parada apartir do id
        /// </summary>
        /// <param name="id">codigo do parada</param>
        /// <returns></returns>
        public Parada Get(string id) => _paradas.Find(book => book.Id == id).FirstOrDefault();

        /// <summary>
        /// cria um novo parada
        /// </summary>
        /// <param name="usuario">dados do parada</param>
        /// <returns></returns>
        public Parada Create(Parada parada)
        {
            _paradas.InsertOne(parada);
            return parada;
        }

        /// <summary>
        /// atualiza um objeto apartir do parada e id
        /// </summary>
        /// <param name="id">codigo do parada</param>
        /// <param name="usuario">parada</param>
        public void Update(string id, Parada usuario) => _paradas.ReplaceOne(book => book.Id == id, usuario);

        /// <summary>
        /// deletar parada apartir de objeto
        /// </summary>
        /// <param name="parada">parada</param>
        public void Remove(Parada parada) => _paradas.DeleteOne(book => book.Id == parada.Id);

        /// <summary>
        /// deleta um parada apartir do id
        /// </summary>
        /// <param name="id">id do parada</param>
        public void Remove(string id) => _paradas.DeleteOne(book => book.Id == id);
    }
}