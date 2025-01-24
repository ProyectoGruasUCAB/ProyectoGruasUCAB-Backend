namespace API_GruasUCAB.Policy.Domain.Repositories
{
     public interface IPolicyRepository
     {
          Task<List<PolicyDTO>> GetAllPoliciesAsync();
          Task<PolicyDTO> GetPolicyByIdAsync(Guid policyId);
          Task<PolicyDTO> GetPolicyByPolicyNumberAsync(string policyNumber);
          Task AddPolicyAsync(PolicyDTO policy);
     }
}