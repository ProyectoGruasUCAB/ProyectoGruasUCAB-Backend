using API_GruasUCAB.Policy.Domain.Entities;
using API_GruasUCAB.Policy.Domain.Repositories;
using API_GruasUCAB.Policy.Infrastructure.Database;
using API_GruasUCAB.Policy.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
                    PolicyId = p.Id,
                    Number = p.Number.Value,
                    Name = p.Name.Value,
                    CoverageAmount = p.CoverageAmount.Value,
                    CoverageKm = p.CoverageKm.Value,
                    BaseAmount = p.BaseAmount.Value,
                    IssueDate = p.IssueDate.Value.ToString("dd-MM-yyyy"),
                    ExpirationDate = p.ExpirationDate.Value.ToString("dd-MM-yyyy")
                })
                .ToListAsync();
        }

        public async Task<PolicyDTO> GetPolicyByIdAsync(Guid id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
            {
                throw new KeyNotFoundException($"Policy with ID {id} not found.");
            }

            return new PolicyDTO
            {
                PolicyId = policy.Id,
                Number = policy.Number.Value,
                Name = policy.Name.Value,
                CoverageAmount = policy.CoverageAmount.Value,
                CoverageKm = policy.CoverageKm.Value,
                BaseAmount = policy.BaseAmount.Value,
                IssueDate = policy.IssueDate.Value.ToString("dd-MM-yyyy"),
                ExpirationDate = policy.ExpirationDate.Value.ToString("dd-MM-yyyy")
            };
        }

        public async Task<PolicyDTO> GetPolicyByPolicyNumberAsync(string policyNumber)
        {
            var policy = await _context.Policies
                .FirstOrDefaultAsync(p => p.Number.Value == policyNumber);
            if (policy == null)
            {
                throw new KeyNotFoundException($"Policy with number {policyNumber} not found.");
            }

            return new PolicyDTO
            {
                PolicyId = policy.Id,
                Number = policy.Number.Value,
                Name = policy.Name.Value,
                CoverageAmount = policy.CoverageAmount.Value,
                CoverageKm = policy.CoverageKm.Value,
                BaseAmount = policy.BaseAmount.Value,
                IssueDate = policy.IssueDate.Value.ToString("dd-MM-yyyy"),
                ExpirationDate = policy.ExpirationDate.Value.ToString("dd-MM-yyyy")
            };
        }

        public async Task AddPolicyAsync(PolicyDTO policyDto)
        {
            var policy = new Policy
            {
                Id = policyDto.PolicyId,
                Number = new PolicyNumber(policyDto.Number),
                Name = new PolicyName(policyDto.Name),
                CoverageAmount = new PolicyCoverageAmount(policyDto.CoverageAmount),
                CoverageKm = new PolicyCoverageKm(policyDto.CoverageKm),
                BaseAmount = new PolicyBaseAmount(policyDto.BaseAmount),
                IssueDate = new PolicyIssueDate(policyDto.IssueDate),
                ExpirationDate = new PolicyExpirationDate(policyDto.ExpirationDate, DateTime.ParseExact(policyDto.ExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            };

            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePolicyAsync(PolicyDTO policyDto)
        {
            var existingPolicy = await _context.Policies.FindAsync(policyDto.PolicyId);
            if (existingPolicy == null)
            {
                throw new KeyNotFoundException($"Policy with ID {policyDto.PolicyId} not found.");
            }

            existingPolicy.Number = new PolicyNumber(policyDto.Number);
            existingPolicy.Name = new PolicyName(policyDto.Name);
            existingPolicy.CoverageAmount = new PolicyCoverageAmount(policyDto.CoverageAmount);
            existingPolicy.CoverageKm = new PolicyCoverageKm(policyDto.CoverageKm);
            existingPolicy.BaseAmount = new PolicyBaseAmount(policyDto.BaseAmount);
            existingPolicy.IssueDate = new PolicyIssueDate(policyDto.IssueDate);
            existingPolicy.ExpirationDate = new PolicyExpirationDate(policyDto.ExpirationDate, DateTime.ParseExact(policyDto.ExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture));

            await _context.SaveChangesAsync();
        }

    }
}