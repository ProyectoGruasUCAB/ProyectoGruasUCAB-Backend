namespace API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials
{
     public interface IHeadersClientCredentialsToken
     {
          Task SetClientCredentialsToken(HttpClient client);
     }
}