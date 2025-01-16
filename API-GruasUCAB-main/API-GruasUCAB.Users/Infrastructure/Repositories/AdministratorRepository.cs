namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class AdministratorRepository : IAdministratorRepository
     {
          private readonly List<AdministratorDTO> _administrators;

          public AdministratorRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _administrators = new List<AdministratorDTO>
            {
                new AdministratorDTO
                {
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin1",
                    Email = "admin1@example.com",
                    Phone = "0416567890",
                    Cedula = "V-12345678",
                    BirthDate = "01-01-2000"
                },
                new AdministratorDTO
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Admin2",
                    Email = "admin2@example.com",
                    Phone = "0416654321",
                    Cedula = "E-87654321",
                    BirthDate = "01-01-2000"
                },
                new AdministratorDTO
                {
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Admin3",
                    Email = "admin3@example.com",
                    Phone = "0416334455",
                    Cedula = "V-11223344",
                    BirthDate = "01-01-2000"
                }
            };
          }

          public async Task<List<AdministratorDTO>> GetAllAdministratorsAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_administrators);
          }

          public async Task<AdministratorDTO> GetAdministratorByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var admin = _administrators.FirstOrDefault(a => a.UserId == id);
               if (admin == null)
               {
                    throw new KeyNotFoundException($"Administrator with ID {id} not found.");
               }
               return await Task.FromResult(admin);
          }

          public async Task<List<AdministratorDTO>> GetAdministratorsByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var admins = _administrators.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!admins.Any())
               {
                    throw new KeyNotFoundException($"No administrators with name containing '{name}' found.");
               }
               return await Task.FromResult(admins);
          }

          public async Task AddAdministratorAsync(AdministratorDTO administrator)
          {
               // Simulación de una llamada a la base de datos
               _administrators.Add(administrator);
               await Task.CompletedTask;
          }

          public async Task UpdateAdministratorAsync(AdministratorDTO administrator)
          {
               // Simulación de una llamada a la base de datos
               var existingAdministrator = _administrators.FirstOrDefault(a => a.UserId == administrator.UserId);
               if (existingAdministrator == null)
               {
                    throw new KeyNotFoundException($"Administrator with ID {administrator.UserId} not found.");
               }

               existingAdministrator.Name = administrator.Name;
               existingAdministrator.Email = administrator.Email;
               existingAdministrator.Phone = administrator.Phone;
               existingAdministrator.Cedula = administrator.Cedula;
               existingAdministrator.BirthDate = administrator.BirthDate;

               await Task.CompletedTask;
          }
     }
}