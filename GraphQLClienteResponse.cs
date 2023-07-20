using MongoDB.Bson.Serialization.Attributes;

namespace DesafioFuncionalAPI
{
    public class GraphQLClienteResponse
    {
        public Cliente Cliente { get; set; }
    }

    public class Cliente
    {
        [BsonElement("Conta")]
        public int Conta { get; set; }

        [BsonElement("Saldo")]
        public double Saldo { get; set; }
    }

}
