namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetServiceOrdersByStatus
{
     public class GetServiceOrdersByStatusQuery : IRequest<GetServiceOrdersByStatusResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Status { get; set; }

          public GetServiceOrdersByStatusQuery(Guid userId, string status)
          {
               UserId = userId;
               Status = status;
          }
     }
}