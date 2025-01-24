namespace API_GruasUCAB.ServiceOrder.Domain.Repositories
{
     public interface IServiceOrderRepository
     {
          Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync();
          Task<ServiceOrderDTO?> GetServiceOrderByIdAsync(Guid serviceOrderId);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByStatusAsync(string status);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByDriverIdAsync(Guid driverId);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByVehicleIdAsync(Guid vehicleId);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByOperatorIdAsync(Guid operatorId);
          Task<List<ServiceOrderDTO>> GetServiceOrdersBySupplierIdAsync(Guid supplierId);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByClientIdAsync(Guid clientId);
          Task AddServiceOrderAsync(ServiceOrderDTO serviceOrder);
          Task UpdateServiceOrderAsync(ServiceOrderDTO serviceOrder);
     }
}