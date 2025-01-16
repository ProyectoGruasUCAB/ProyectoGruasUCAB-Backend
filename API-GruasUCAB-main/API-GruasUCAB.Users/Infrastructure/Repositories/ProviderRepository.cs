namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class ProviderRepository : IProviderRepository
     {
          private readonly List<ProviderDTO> _providers;

          public ProviderRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _providers = new List<ProviderDTO>
            {
                new ProviderDTO
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "aaaaa",
                    UserEmail = "aaa@aaa.com",
                    Phone = "04140834357",
                    Cedula = "V-28686611",
                    BirthDate = "12-12-2000"
                },
                new ProviderDTO
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Name = "bbbb",
                    UserEmail = "bbb@bbb.com",
                    Phone = "04140834358",
                    Cedula = "V-28686612",
                    BirthDate = "10-10-1995"
                },
                new ProviderDTO
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Name = "cccc",
                    UserEmail = "ccc@ccc.com",
                    Phone = "04140834359",
                    Cedula = "V-28686613",
                    BirthDate = "05-05-1990"
                }
            };
          }

          public async Task<List<ProviderDTO>> GetAllProvidersAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_providers);
          }

          public async Task<ProviderDTO> GetProviderByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var provider = _providers.FirstOrDefault(p => p.Id == id);
               if (provider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {id} not found.");
               }
               return await Task.FromResult(provider);
          }

          public async Task<List<ProviderDTO>> GetProvidersByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var providers = _providers.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!providers.Any())
               {
                    throw new KeyNotFoundException($"No providers with name containing '{name}' found.");
               }
               return await Task.FromResult(providers);
          }

          public async Task AddProviderAsync(ProviderDTO provider)
          {
               // Simulación de una llamada a la base de datos
               _providers.Add(provider);
               await Task.CompletedTask;
          }

          public async Task UpdateProviderAsync(ProviderDTO provider)
          {
               // Simulación de una llamada a la base de datos
               var existingProvider = _providers.FirstOrDefault(p => p.Id == provider.Id);
               if (existingProvider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {provider.Id} not found.");
               }

               existingProvider.Name = provider.Name;
               existingProvider.UserEmail = provider.UserEmail;
               existingProvider.Phone = provider.Phone;
               existingProvider.Cedula = provider.Cedula;
               existingProvider.BirthDate = provider.BirthDate;

               await Task.CompletedTask;
          }
     }
}