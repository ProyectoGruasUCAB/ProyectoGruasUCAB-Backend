namespace API_GruasUCAB.ServiceOrder.Domain.Services
{
     public class ServiceOrderDomainService
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IVehicleRepository _vehicleRepository;

          public ServiceOrderDomainService(IServiceOrderRepository serviceOrderRepository, IVehicleRepository vehicleRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _vehicleRepository = vehicleRepository;
          }

          public async Task ValidateClientCanCreateOrder(Guid clientId)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByClientIdAsync(clientId);
               if (serviceOrders.Any(so => so.StatusServiceOrder != ServiceOrderStatus.Finalizado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.Pagado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.Cancelado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.CanceladoPorCobrar.ToString()))
               {
                    throw new InvalidOperationException("Client already has an active service order.");
               }
          }

          public async Task ValidateDriverCanCreateOrder(Guid driverId, Guid vehicleId)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByDriverIdAsync(driverId);
               if (serviceOrders.Any(so => so.StatusServiceOrder != ServiceOrderStatus.Finalizado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.Pagado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.Cancelado.ToString() &&
                                           so.StatusServiceOrder != ServiceOrderStatus.CanceladoPorCobrar.ToString()))
               {
                    throw new InvalidOperationException("Driver already has an active service order.");
               }

               var vehicle = await _vehicleRepository.GetVehicleByDriverIdAsync(driverId);
               if (vehicle == null || vehicle.VehicleId != vehicleId)
               {
                    throw new InvalidOperationException("The vehicle does not match the driver.");
               }
          }
     }
}