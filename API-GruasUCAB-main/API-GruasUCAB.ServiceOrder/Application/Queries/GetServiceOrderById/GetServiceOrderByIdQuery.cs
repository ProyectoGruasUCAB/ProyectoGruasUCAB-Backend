namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetServiceOrderById
{
     public class GetServiceOrderByIdQuery : IRequest<GetServiceOrderByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid ServiceOrderId { get; set; }

          public GetServiceOrderByIdQuery(Guid userId, Guid serviceOrderId)
          {
               UserId = userId;
               ServiceOrderId = serviceOrderId;
          }
     }
}