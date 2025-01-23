namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetOrdersByOperatorId
{
     public class GetOrdersByOperatorIdQuery : IRequest<GetOrdersByOperatorIdResponseDTO>
     {
          public Guid OperatorId { get; set; }

          public GetOrdersByOperatorIdQuery(Guid operatorId)
          {
               OperatorId = operatorId;
          }
     }
}