namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetOrdersByClientId
{
     public class GetOrdersByClientIdQuery : IRequest<GetOrdersByClientIdResponseDTO>
     {
          public Guid ClientId { get; set; }

          public GetOrdersByClientIdQuery(Guid clientId)
          {
               ClientId = clientId;
          }
     }
}