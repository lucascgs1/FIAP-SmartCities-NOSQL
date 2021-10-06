using MongoDB.Driver;
using PokeM.Models.Documents;
using PokeM.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeM.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IPokeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.BooksCollectionName);
        }

        public List<Usuario> Get() =>
            _usuarios.Find(book => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(book => book.Id == id).FirstOrDefault();

        public Usuario Create(Usuario book)
        {
            _usuarios.InsertOne(book);
            return book;
        }

        public void Update(string id, Usuario bookIn) =>
            _usuarios.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Usuario bookIn) =>
            _usuarios.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _usuarios.DeleteOne(book => book.Id == id);
    }
}
