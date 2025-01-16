namespace API_GruasUCAB.Policy.Infrastructure.Repositories
{
     public class PolicyRepository : IPolicyRepository
     {
          private readonly List<PolicyDTO> _policies;

          public PolicyRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _policies = new List<PolicyDTO>
            {
                new PolicyDTO
                {
                    PolicyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    PolicyNumber = "123456",
                    PolicyName = "Basic Coverage",
                    PolicyCoverageAmount = 10000,
                    PolicyCoverageKm = 100,
                    PolicyBaseAmount = 500,
                    PolicyPriceKm = 5,
                    PolicyIssueDate = "01-01-2023",
                    PolicyExpirationDate = "01-01-2024",
                    PolicyClientId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new PolicyDTO
                {
                    PolicyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    PolicyNumber = "654321",
                    PolicyName = "Premium Coverage",
                    PolicyCoverageAmount = 50000,
                    PolicyCoverageKm = 500,
                    PolicyBaseAmount = 2000,
                    PolicyPriceKm = 10,
                    PolicyIssueDate = "01-01-2023",
                    PolicyExpirationDate = "01-01-2025",
                    PolicyClientId = Guid.Parse("44444444-4444-4444-4444-444444444444")
                }
            };
          }

          public async Task<List<PolicyDTO>> GetAllPoliciesAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_policies);
          }

          public async Task<PolicyDTO> GetPolicyByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var policy = _policies.FirstOrDefault(p => p.PolicyId == id);
               if (policy == null)
               {
                    throw new KeyNotFoundException($"Policy with ID {id} not found.");
               }
               return await Task.FromResult(policy);
          }

          public async Task<PolicyDTO> GetPolicyByPolicyNumberAsync(string policyNumber)
          {
               // Simulación de una llamada a la base de datos
               var policy = _policies.FirstOrDefault(p => p.PolicyNumber == policyNumber);
               if (policy == null)
               {
                    throw new KeyNotFoundException($"Policy with number {policyNumber} not found.");
               }
               return await Task.FromResult(policy);
          }

          public async Task AddPolicyAsync(PolicyDTO policy)
          {
               // Simulación de una llamada a la base de datos
               _policies.Add(policy);
               await Task.CompletedTask;
          }

          public async Task UpdatePolicyAsync(PolicyDTO policy)
          {
               // Simulación de una llamada a la base de datos
               var existingPolicy = _policies.FirstOrDefault(p => p.PolicyId == policy.PolicyId);
               if (existingPolicy == null)
               {
                    throw new KeyNotFoundException($"Policy with ID {policy.PolicyId} not found.");
               }

               existingPolicy.PolicyNumber = policy.PolicyNumber;
               existingPolicy.PolicyName = policy.PolicyName;
               existingPolicy.PolicyCoverageAmount = policy.PolicyCoverageAmount;
               existingPolicy.PolicyCoverageKm = policy.PolicyCoverageKm;
               existingPolicy.PolicyBaseAmount = policy.PolicyBaseAmount;
               existingPolicy.PolicyPriceKm = policy.PolicyPriceKm;
               existingPolicy.PolicyIssueDate = policy.PolicyIssueDate;
               existingPolicy.PolicyExpirationDate = policy.PolicyExpirationDate;
               existingPolicy.PolicyClientId = policy.PolicyClientId;

               await Task.CompletedTask;
          }
     }
}