namespace API_GruasUCAB.ServiceFee.Domain.Factories
{
     public class ServiceFeeFactory : IServiceFeeFactory
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;

          public ServiceFeeFactory(IServiceFeeRepository serviceFeeRepository)
          {
               _serviceFeeRepository = serviceFeeRepository;
          }

          public AggregateRoot.ServiceFee CreateServiceFee(
              ServiceFeeId id,
              ServiceFeeName name,
              ServiceFeePrice price,
              ServiceFeePriceKm priceKm,
              ServiceFeeRadius radius)
          {
               return new AggregateRoot.ServiceFee(id, name, price, priceKm, radius);
          }

          public async Task<AggregateRoot.ServiceFee> GetServiceFeeById(ServiceFeeId id)
          {
               var serviceFeeDTO = await _serviceFeeRepository.GetServiceFeeByIdAsync(id.Id);
               return new AggregateRoot.ServiceFee(
                   new ServiceFeeId(serviceFeeDTO.ServiceFeeId),
                   new ServiceFeeName(serviceFeeDTO.Name),
                   new ServiceFeePrice(serviceFeeDTO.Price),
                   new ServiceFeePriceKm(serviceFeeDTO.PriceKm),
                   new ServiceFeeRadius(serviceFeeDTO.Radius)
               );
          }
     }
}