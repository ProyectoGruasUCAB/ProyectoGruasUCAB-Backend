namespace API_GruasUCAB.Policy.Infrastructure.DTOs.PolicyQueries
{
     public class GetAllPoliciesResponseDTO
     {
          public List<PolicyDTO> Policies { get; set; } = new List<PolicyDTO>();
     }
}