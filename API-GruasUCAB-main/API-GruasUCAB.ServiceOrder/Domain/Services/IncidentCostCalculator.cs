global using PolicyAggregate = API_GruasUCAB.Policy.Domain.AggregateRoot;
global using ServiceFeeAggregate = API_GruasUCAB.ServiceFee.Domain.AggregateRoot;

namespace API_GruasUCAB.ServiceOrder.Domain.Services
{
     public class IncidentCostCalculator
     {
          private readonly IPolicyRepository _policyRepository;
          private readonly IServiceFeeRepository _serviceFeeRepository;

          public IncidentCostCalculator(IPolicyRepository policyRepository, IServiceFeeRepository serviceFeeRepository)
          {
               _policyRepository = policyRepository;
               _serviceFeeRepository = serviceFeeRepository;
          }

          public async Task<decimal> CalculateIncidentCost(
              Guid policyId,
              Guid serviceFeeId,
              IncidentDistance incidentDistance)
          {
               var policyDto = await _policyRepository.GetPolicyByIdAsync(policyId);
               var serviceFeeDto = await _serviceFeeRepository.GetServiceFeeByIdAsync(serviceFeeId);

               var policy = new PolicyAggregate.Policy(
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

               var serviceFee = new ServiceFeeAggregate.ServiceFee(
                   new ServiceFeeId(serviceFeeDto.ServiceFeeId),
                   new ServiceFeeName(serviceFeeDto.Name),
                   new ServiceFeePrice(serviceFeeDto.Price),
                   new ServiceFeePriceKm(serviceFeeDto.PriceKm),
                   new ServiceFeeRadius(serviceFeeDto.Radius),
                   new ServiceFeeDescription(serviceFeeDto.Description)
               );

               var baseCost = (decimal)serviceFee.Price.Value;
               var additionalCost = incidentDistance.Value > policy.PolicyCoverageKm.Value
                   ? ((decimal)incidentDistance.Value - policy.PolicyCoverageKm.Value) * (decimal)serviceFee.PriceKm.Value
                   : 0;
               var totalCost = baseCost + additionalCost;
               var coverageDifference = policy.PolicyCoverageAmount.Value - totalCost;
               var amountToPay = coverageDifference < 0 ? -coverageDifference : 0;
               return amountToPay;
          }
     }
}