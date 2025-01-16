namespace API_GruasUCAB.Users.Domain.Repositories
{
     public interface IProviderRepository
     {
          Task<List<ProviderDTO>> GetAllProvidersAsync();
          Task<ProviderDTO> GetProviderByIdAsync(Guid id);
          Task<List<ProviderDTO>> GetProvidersByNameAsync(string name);
          Task AddProviderAsync(ProviderDTO provider);
          Task UpdateProviderAsync(ProviderDTO provider);
     }
}