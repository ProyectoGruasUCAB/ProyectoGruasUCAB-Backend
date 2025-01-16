namespace API_GruasUCAB.Policy.Application.Queries.GetAllPolicies
{
     public class GetAllPoliciesQuery : IRequest<GetAllPoliciesResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllPoliciesQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}