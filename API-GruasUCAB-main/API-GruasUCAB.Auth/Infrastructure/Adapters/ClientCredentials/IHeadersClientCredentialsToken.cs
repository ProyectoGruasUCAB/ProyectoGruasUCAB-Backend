using System.Threading.Tasks;
using System.Net.Http;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials
{
     public interface IHeadersClientCredentialsToken
     {
          Task SetClientCredentialsToken(HttpClient client);
     }
}