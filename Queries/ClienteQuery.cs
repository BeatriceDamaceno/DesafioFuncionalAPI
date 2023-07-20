using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace DesafioFuncionalAPI.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class ClienteQuery
    {
        public async Task<Cliente> Saldo([Service] IMongoCollection<Cliente> collection, int conta)
        {
            var cliente = await collection.Find(c => c.Conta == conta).FirstOrDefaultAsync();

            if (cliente == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            return cliente;
        }
    }
}
