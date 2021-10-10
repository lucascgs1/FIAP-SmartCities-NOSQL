using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PokeM.Api.Models.Documents
{
    public class Veiculo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("_plac")]
        public string Placa { get; set; }

        [BsonElement("_assent")]
        public int Qtd_assentos { get; set; }

        [BsonElement("_ano")]
        public int Ano { get; set; }

        [BsonElement("_tipveic")]
        public string TipoVeiculo { get; set; }

        [BsonElement("_wifi")]
        public bool Wifi { get; set; }

        [BsonElement("_banh")]
        public bool Banheiro { get; set; }

        [BsonElement("_lanch")]
        public bool Lanches { get; set; }

        [BsonElement("_arcond")]
        public bool ArCondicionado { get; set; }

        [BsonElement("_datacad")]
        public DateTime DataCadastro { get; set; }
    }
}