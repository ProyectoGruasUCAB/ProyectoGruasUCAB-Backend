namespace API_GruasUCAB.ServiceFee.Domain.Factories
{
     public class ServiceFeeFactory : IServiceFeeFactory
     {
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
               // Implementa la lógica para obtener la tarifa de servicio por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new AggregateRoot.ServiceFee(id, new ServiceFeeName("Example"), new ServiceFeePrice(100), new ServiceFeePriceKm(10), new ServiceFeeRadius(5)));
          }
     }
}