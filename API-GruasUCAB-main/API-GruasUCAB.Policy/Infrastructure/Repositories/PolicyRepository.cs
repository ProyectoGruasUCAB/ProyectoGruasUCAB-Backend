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
                    Number = "123456",
                    Name = "Basic Coverage",
                    CoverageAmount = 10000,
                    CoverageKm = 100,
                    BaseAmount = 500,
                    PriceKm = 5,
                    IssueDate = "01-01-2023",
                    ExpirationDate = "01-01-2024",
                    ClientId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new PolicyDTO
                {
                    PolicyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Number = "654321",
                    Name = "Premium Coverage",
                    CoverageAmount = 50000,
                    CoverageKm = 500,
                    BaseAmount = 2000,
                    PriceKm = 10,
                    IssueDate = "01-01-2023",
                    ExpirationDate = "01-01-2025",
                    ClientId = Guid.Parse("44444444-4444-4444-4444-444444444444")
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
               var policy = _policies.FirstOrDefault(p => p.Number == policyNumber);
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

               existingPolicy.Number = policy.Number;
               existingPolicy.Name = policy.Name;
               existingPolicy.CoverageAmount = policy.CoverageAmount;
               existingPolicy.CoverageKm = policy.CoverageKm;
               existingPolicy.BaseAmount = policy.BaseAmount;
               existingPolicy.PriceKm = policy.PriceKm;
               existingPolicy.IssueDate = policy.IssueDate;
               existingPolicy.ExpirationDate = policy.ExpirationDate;
               existingPolicy.ClientId = policy.ClientId;

               await Task.CompletedTask;
          }
     }
}