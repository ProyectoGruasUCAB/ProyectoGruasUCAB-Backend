namespace API_GruasUCAB.ServiceFee.Domain.Factories
{
     public interface IServiceFeeFactory
     {
          AggregateRoot.ServiceFee CreateServiceFee(
              ServiceFeeId id,
              ServiceFeeName name,
              ServiceFeePrice price,
              ServiceFeePriceKm priceKm,
              ServiceFeeRadius radius,
              ServiceFeeDescription description);

          Task<AggregateRoot.ServiceFee> GetServiceFeeById(ServiceFeeId id);
     }
}