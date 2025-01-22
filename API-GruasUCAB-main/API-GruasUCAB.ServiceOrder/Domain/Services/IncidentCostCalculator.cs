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

               // Calcular el costo base del incidente
               var baseCost = (decimal)serviceFee.Price.Value;
               Console.WriteLine($"Base Cost: {baseCost}");

               // Calcular el costo adicional por kilómetro
               var additionalCost = incidentDistance.Value > policy.PolicyCoverageKm.Value
                   ? ((decimal)incidentDistance.Value - policy.PolicyCoverageKm.Value) * (decimal)serviceFee.PriceKm.Value
                   : 0;
               Console.WriteLine($"Additional Cost: {additionalCost}");

               // Calcular el costo total del incidente
               var totalCost = baseCost + additionalCost;
               Console.WriteLine($"Total Cost before coverage check: {totalCost}");

               // Verificar si el costo total excede la cobertura de la póliza
               if (totalCost > policy.PolicyCoverageAmount.Value)
               {
                    totalCost = policy.PolicyCoverageAmount.Value;
               }
               Console.WriteLine($"Total Cost after coverage check: {totalCost}");

               return totalCost;
          }
     }
}