namespace API_GruasUCAB.ServiceOrder.Domain.Repositories
{
     public interface IServiceOrderRepository
     {
          Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync();
          Task<ServiceOrderDTO?> GetServiceOrderByIdAsync(Guid serviceOrderId);
          Task AddServiceOrderAsync(ServiceOrderDTO serviceOrder);
          Task UpdateServiceOrderAsync(ServiceOrderDTO serviceOrder);
          Task<List<ServiceOrderDTO>> GetServiceOrdersByStatusAsync(string status);
     }
}