namespace API_GruasUCAB.ServiceFee.Application.Queries.GetAllServiceFees
{
     public class GetAllServiceFeesQuery : IRequest<GetAllServiceFeesResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllServiceFeesQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}