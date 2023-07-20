using DesafioFuncionalAPI;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;

var graphQLHttpClientOptions = new GraphQLHttpClientOptions
{
    EndPoint = new Uri("https://us-east-1.aws.realm.mongodb.com/api/client/v2.0/app/funcionalapi-aktka/graphql")
};

var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("apiKey", "1VtsKydvohhwd2Jojr4dcQCHagJKBLpEyH2MWi2ELoUSUS7dHUwwFGryNCCTmQy5");

var graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer(), httpClient);

/*
 Console.WriteLine("Insira o número da conta:");
string Conta = Console.ReadLine();


var saldoRequest = new GraphQLRequest
{
    Query = @"
        {
            cliente(query: {conta: " + Conta + @"}) {
                conta,
                saldo
            }
        }
    "
};

var graphQLResponse = await graphQLClient.SendQueryAsync<GraphQLClienteResponse>(saldoRequest);


Console.WriteLine("{0}: {1}", graphQLResponse.Data.Cliente.Conta, graphQLResponse.Data.Cliente.Saldo);
Console.ReadLine();
*/