namespace API_GruasUCAB.ServiceFee.Application.Queries.GetServiceFeeByName
{
     public class GetServiceFeeByNameQuery : IRequest<GetServiceFeeByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetServiceFeeByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}