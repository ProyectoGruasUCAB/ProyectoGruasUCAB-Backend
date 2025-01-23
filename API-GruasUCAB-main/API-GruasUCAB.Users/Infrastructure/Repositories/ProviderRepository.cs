namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class ProviderRepository : IProviderRepository
     {
          private readonly UserDbContext _context;

          public ProviderRepository(UserDbContext context)
          {
               _context = context;
          }

          public async Task<List<ProviderDTO>> GetAllProvidersAsync()
          {
               var providers = await _context.Providers.ToListAsync();
               return providers.Select(provider => provider.ToDTO()).ToList();
          }

          public async Task<ProviderDTO> GetProviderByIdAsync(Guid id)
          {
               var provider = await _context.Providers.FindAsync(new UserId(id));
               if (provider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {id} not found.");
               }

               return provider.ToDTO();
          }

          public async Task<List<ProviderDTO>> GetProvidersByNameAsync(string name)
          {
               var providers = await _context.Providers
                   .ToListAsync();

               var filteredProviders = providers
                   .Where(p => p.Name.Value.ToLower().Contains(name.ToLower()))
                   .ToList();

               if (!filteredProviders.Any())
               {
                    throw new KeyNotFoundException($"No providers with name containing '{name}' found.");
               }

               return filteredProviders.Select(provider => provider.ToDTO()).ToList();
          }

          public async Task AddProviderAsync(ProviderDTO providerDto)
          {
               var provider = providerDto.ToEntity();
               _context.Providers.Add(provider);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateProviderAsync(ProviderDTO providerDto)
          {
               var existingProvider = await _context.Providers.FindAsync(new UserId(providerDto.Id));
               if (existingProvider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {providerDto.Id} not found.");
               }

               var updatedProvider = providerDto.ToEntity();
               _context.Entry(existingProvider).CurrentValues.SetValues(updatedProvider);
               await _context.SaveChangesAsync();
          }
     }
}