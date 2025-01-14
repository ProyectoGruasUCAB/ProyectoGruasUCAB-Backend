namespace API_GruasUCAB.ServiceFee.Domain.Repositories
{
     public interface IServiceFeeRepository
     {
          Task<List<ServiceFeeDTO>> GetAllServiceFeesAsync();
          Task<ServiceFeeDTO> GetServiceFeeByIdAsync(Guid id);
          Task<ServiceFeeDTO> GetServiceFeeByNameAsync(string name);
     }
}