namespace API_GruasUCAB.ServiceFee.Domain.Repositories
{
     public interface IServiceFeeRepository
     {
          Task<List<ServiceFeeDTO>> GetAllServiceFeesAsync();
          Task<ServiceFeeDTO> GetServiceFeeByIdAsync(Guid id);
          Task<List<ServiceFeeDTO>> GetServiceFeeByNameAsync(string name);
          Task AddServiceFeeAsync(ServiceFeeDTO serviceFee);
          Task UpdateServiceFeeAsync(ServiceFeeDTO serviceFee);
     }
}