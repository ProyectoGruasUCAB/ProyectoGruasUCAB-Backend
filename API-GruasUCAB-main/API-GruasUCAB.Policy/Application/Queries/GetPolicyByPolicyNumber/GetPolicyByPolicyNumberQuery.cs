namespace API_GruasUCAB.Policy.Application.Queries.GetPolicyByPolicyNumber
{
     public class GetPolicyByPolicyNumberQuery : IRequest<GetPolicyByPolicyNumberResponseDTO>
     {
          public Guid UserId { get; set; }
          public string PolicyNumber { get; set; }

          public GetPolicyByPolicyNumberQuery(Guid userId, string policyNumber)
          {
               UserId = userId;
               PolicyNumber = policyNumber;
          }
     }
}