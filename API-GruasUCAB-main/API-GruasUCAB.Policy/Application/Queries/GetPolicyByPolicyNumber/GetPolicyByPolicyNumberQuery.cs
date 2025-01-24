namespace API_GruasUCAB.Policy.Application.Queries.GetPolicyByPolicyNumber
{
     public class GetPolicyByPolicyNumberQuery : IRequest<GetPolicyByPolicyNumberResponseDTO>
     {
          public string PolicyNumber { get; }

          public GetPolicyByPolicyNumberQuery(string policyNumber)
          {
               PolicyNumber = policyNumber;
          }
     }
}