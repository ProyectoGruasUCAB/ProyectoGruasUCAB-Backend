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
                    Phone = "1234567890",
                    Cedula = "12345678",
                    BirthDate = "01-01-2000"
                },
                new AdministratorDTO
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Admin2",
                    Email = "admin2@example.com",
                    Phone = "0987654321",
                    Cedula = "87654321",
                    BirthDate = "01-01-2000"
                },
                new AdministratorDTO
                {
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Admin3",
                    Email = "admin3@example.com",
                    Phone = "1122334455",
                    Cedula = "11223344",
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
     }
}