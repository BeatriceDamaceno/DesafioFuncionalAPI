using HotChocolate.Types;

namespace DesafioFuncionalAPI
{
    public class ClienteType : ObjectType<Cliente>
    {
        protected override void Configure(IObjectTypeDescriptor<Cliente> descriptor)
        {
            descriptor.Field(a => a.Conta).Type<IntType>();
            descriptor.Field(a => a.Saldo).Type<FloatType>();
        }

    }
}
