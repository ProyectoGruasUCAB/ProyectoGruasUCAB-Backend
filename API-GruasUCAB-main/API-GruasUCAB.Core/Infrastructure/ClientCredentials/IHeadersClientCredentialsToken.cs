using System.Net.Http;
using System.Threading.Tasks;

namespace API_GruasUCAB.Core.Infrastructure.ClientCredentials
{
     public interface IHeadersClientCredentialsToken
     {
          Task SetClientCredentialsToken(HttpClient client);
     }
}