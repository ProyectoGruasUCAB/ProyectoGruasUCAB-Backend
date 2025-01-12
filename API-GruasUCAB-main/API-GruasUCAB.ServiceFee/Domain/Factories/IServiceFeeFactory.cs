using API_GruasUCAB.ServiceFee.Domain.AggregateRoot;

namespace API_GruasUCAB.ServiceFee.Domain.Factories
{
     public interface IServiceFeeFactory
     {
          AggregateRoot.ServiceFee CreateServiceFee(
               ServiceFeeId id,
               ServiceFeeName name,
               ServiceFeePrice price,
               ServiceFeePriceKm priceKm,
               ServiceFeeRadius radius);

          Task<AggregateRoot.ServiceFee> GetServiceFeeById(ServiceFeeId id);
     }
}