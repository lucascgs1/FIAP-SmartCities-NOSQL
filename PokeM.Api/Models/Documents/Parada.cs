using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeM.Api.Models.Documents
{
    public class Parada
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("_nome")]
        public string Nome { get; set; }

        [BsonElement("_local")]
        public string Local { get; set; }

        [BsonElement("_lat")]
        public float? Latitude { get; set; }

        [BsonElement("_long")]
        public float? Longitude { get; set; }

        [BsonElement("_datacad")]
        public DateTime DataCadastro{ get; set; }
    }
}
