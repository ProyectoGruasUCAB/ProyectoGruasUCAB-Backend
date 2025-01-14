namespace API_GruasUCAB.ServiceFee.Application.Queries.GetServiceFeeById
{
     public class GetServiceFeeByIdQuery : IRequest<GetServiceFeeByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid ServiceFeeId { get; set; }

          public GetServiceFeeByIdQuery(Guid userId, Guid serviceFeeId)
          {
               UserId = userId;
               ServiceFeeId = serviceFeeId;
          }
     }
}