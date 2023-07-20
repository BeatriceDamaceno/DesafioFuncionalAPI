using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.MongoDb;
using HotChocolate.Types;
using MongoDB.Driver;

namespace DesafioFuncionalAPI.Schemas
{
    public class ClientSchema
    {
    }

    [ExtendObjectType(Name = "Mutation")]
    public class ClienteMutations
    {
        //[UseMongoDbCollection("clientes")]
        public async Task<bool> Sacar([Service] IMongoCollection<Cliente> collection, TransacInput input)
        {
            var cliente = await collection.Find(c => c.Conta == input.Conta).FirstOrDefaultAsync();

            if (cliente == null)
            {
                throw new ArgumentException("A conta informada não foi encontrada.");
            }

            if (cliente.Saldo < input.Valor)
            {
                throw new ArgumentException("Saldo insuficiente.");
            }

            var filter = Builders<Cliente>.Filter.Eq(c => c.Conta, input.Conta);
            var update = Builders<Cliente>.Update.Inc(c => c.Saldo, -input.Valor);

            var result = await collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> Depositar([Service] IMongoCollection<Cliente> collection, TransacInput input)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Conta, input.Conta);
            var update = Builders<Cliente>.Update.Inc(c => c.Saldo, +input.Valor);

            var result = await collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
    }
}
