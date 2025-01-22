namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Queries
{
     public class GetClientByClientNumberQuery : IRequest<ClientDTO>
     {
          public string ClientNumber { get; }

          public GetClientByClientNumberQuery(string clientNumber)
          {
               ClientNumber = clientNumber;
          }
     }
}