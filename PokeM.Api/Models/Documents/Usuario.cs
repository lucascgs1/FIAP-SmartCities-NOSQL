using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeM.Api.Models.Documents
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("_nome")]
        public string Nome { get; set; }

        [BsonElement("_sob")]
        public string Sobrenome{ get; set; }

        [BsonElement("_ema")]
        public string Email{ get; set; }

        [BsonElement("_pass")]
        public string Senha{ get; set; }

        [BsonElement("_ende")]
        public string Endereco{ get; set; }

        [BsonElement("_cpf")]
        public string CPF{ get; set; }

        [BsonElement("_tel")]
        public string Telefone{ get; set; }

        [BsonElement("_codseg")]
        public string CodigoSeguranca{ get; set; }

        [BsonElement("_datacad")]
        public DateTime DataCadastro{ get; set; }
    }
}
D