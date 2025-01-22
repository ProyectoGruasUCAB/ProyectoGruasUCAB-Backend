namespace API_GruasUCAB.Policy.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolicyDbContext _context;

        public PolicyRepository(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task<List<PolicyDTO>> GetAllPoliciesAsync()
        {
            return await _context.Policies
                .Select(p => new PolicyDTO
                {
                    PolicyId = p.Id.Value,
                    Number = p.PolicyNumber.Value,
                    Name = p.PolicyName.Value,
                    CoverageAmount = p.PolicyCoverageAmount.Value,
                    CoverageKm = p.PolicyCoverageKm.Value,
                    BaseAmount = p.PolicyBaseAmount.Value,
                    IssueDate = p.PolicyIssueDate.Value.ToString("dd-MM-yyyy"),
                    ExpirationDate = p.PolicyExpirationDate.Value.ToString("dd-MM-yyyy"),
                    ClientId = p.PolicyClient.Value
                })
                .ToListAsync();
        }

        public async Task<PolicyDTO> GetPolicyByIdAsync(Guid id)
        {
            var policy = await _context.Policies.FindAsync(new PolicyId(id));
            if (policy == null)
            {
                throw new KeyNotFoundException($"Policy with ID {id} not found.");
            }

            // Verificar el valor del número de póliza
            if (string.IsNullOrWhiteSpace(policy.PolicyNumber.Value))
            {
                throw new Exception("Invalid policy number");
            }

            return new PolicyDTO
            {
                PolicyId = policy.Id.Value,
                Number = policy.PolicyNumber.Value,
                Name = policy.PolicyName.Value,
                CoverageAmount = policy.PolicyCoverageAmount.Value,
                CoverageKm = policy.PolicyCoverageKm.Value,
                BaseAmount = policy.PolicyBaseAmount.Value,
                IssueDate = policy.PolicyIssueDate.Value.ToString("dd-MM-yyyy"),
                ExpirationDate = policy.PolicyExpirationDate.Value.ToString("dd-MM-yyyy"),
                ClientId = policy.PolicyClient.Value
            };
        }

        public async Task<PolicyDTO> GetPolicyByPolicyNumberAsync(string policyNumber)
        {
            var policy = await _context.Policies
                .FirstOrDefaultAsync(p => p.PolicyNumberValue == policyNumber);
            if (policy == null)
            {
                throw new KeyNotFoundException($"Policy with number {policyNumber} not found.");
            }

            return new PolicyDTO
            {
                PolicyId = policy.Id.Value,
                Number = policy.PolicyNumber.Value,
                Name = policy.PolicyName.Value,
                CoverageAmount = policy.PolicyCoverageAmount.Value,
                CoverageKm = policy.PolicyCoverageKm.Value,
                BaseAmount = policy.PolicyBaseAmount.Value,
                IssueDate = policy.PolicyIssueDate.Value.ToString("dd-MM-yyyy"),
                ExpirationDate = policy.PolicyExpirationDate.Value.ToString("dd-MM-yyyy"),
                ClientId = policy.PolicyClient.Value
            };
        }

        public async Task AddPolicyAsync(PolicyDTO policyDto)
        {
            var policy = new PolicyAggregate(
                new PolicyId(policyDto.PolicyId),
                new PolicyNumber(policyDto.Number),
                new PolicyName(policyDto.Name),
                new PolicyCoverageAmount(policyDto.CoverageAmount),
                new PolicyCoverageKm(policyDto.CoverageKm),
                new PolicyBaseAmount(policyDto.BaseAmount),
                new PolicyPriceKm(policyDto.PriceKm),
                new PolicyIssueDate(policyDto.IssueDate),
                new PolicyExpirationDate(policyDto.ExpirationDate, DateTime.ParseExact(policyDto.IssueDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                new PolicyClient(policyDto.ClientId)
            );

            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
        }
    }
}