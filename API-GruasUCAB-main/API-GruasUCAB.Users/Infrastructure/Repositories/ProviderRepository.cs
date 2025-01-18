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
               return await _context.Suppliers
                   .Select(p => new ProviderDTO
                   {
                        Id = p.Id.Value,
                        Name = p.Name.Value,
                        UserEmail = p.Email.Value,
                        Phone = p.Phone.Value,
                        Cedula = p.Cedula.Value,
                        BirthDate = p.BirthDate.Value.ToString("dd-MM-yyyy")
                   })
                   .ToListAsync();
          }

          public async Task<ProviderDTO> GetProviderByIdAsync(Guid id)
          {
               var provider = await _context.Suppliers.FindAsync(new UserId(id));
               if (provider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {id} not found.");
               }

               return new ProviderDTO
               {
                    Id = provider.Id.Value,
                    Name = provider.Name.Value,
                    UserEmail = provider.Email.Value,
                    Phone = provider.Phone.Value,
                    Cedula = provider.Cedula.Value,
                    BirthDate = provider.BirthDate.Value.ToString("dd-MM-yyyy")
               };
          }

          public async Task<List<ProviderDTO>> GetProvidersByNameAsync(string name)
          {
               var providers = await _context.Suppliers
                   .ToListAsync();

               var filteredProviders = providers
                   .Where(p => p.Name.Value.ToLower().Contains(name.ToLower()))
                   .Select(p => new ProviderDTO
                   {
                        Id = p.Id.Value,
                        Name = p.Name.Value,
                        UserEmail = p.Email.Value,
                        Phone = p.Phone.Value,
                        Cedula = p.Cedula.Value,
                        BirthDate = p.BirthDate.Value.ToString("dd-MM-yyyy")
                   })
                   .ToList();

               if (!filteredProviders.Any())
               {
                    throw new KeyNotFoundException($"No providers with name containing '{name}' found.");
               }

               return filteredProviders;
          }

          public async Task AddProviderAsync(ProviderDTO providerDto)
          {
               var provider = new Supplier(
                   new UserId(providerDto.Id),
                   new UserName(providerDto.Name),
                   new UserEmail(providerDto.UserEmail),
                   new UserPhone(providerDto.Phone),
                   new UserCedula(providerDto.Cedula),
                   new UserBirthDate(providerDto.BirthDate)
               );

               _context.Suppliers.Add(provider);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateProviderAsync(ProviderDTO providerDto)
          {
               var existingProvider = await _context.Suppliers.FindAsync(new UserId(providerDto.Id));
               if (existingProvider == null)
               {
                    throw new KeyNotFoundException($"Provider with ID {providerDto.Id} not found.");
               }

               existingProvider.ChangeName(new UserName(providerDto.Name));
               existingProvider.ChangePhone(new UserPhone(providerDto.Phone));
               existingProvider.ChangeBirthDate(new UserBirthDate(providerDto.BirthDate));

               await _context.SaveChangesAsync();
          }
     }
}