namespace API_GruasUCAB.Policy.Application.Queries.GetPolicyById
{
     public class GetPolicyByIdQuery : IRequest<GetPolicyByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid PolicyId { get; set; }

          public GetPolicyByIdQuery(Guid userId, Guid policyId)
          {
               UserId = userId;
               PolicyId = policyId;
          }
     }
}