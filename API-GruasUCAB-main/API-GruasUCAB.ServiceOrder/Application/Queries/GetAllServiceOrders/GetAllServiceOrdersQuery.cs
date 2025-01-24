namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetAllServiceOrders
{
     public class GetAllServiceOrdersQuery : IRequest<GetAllServiceOrdersResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllServiceOrdersQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}