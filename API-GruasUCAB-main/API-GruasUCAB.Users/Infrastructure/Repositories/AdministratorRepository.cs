namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class AdministratorRepository : IAdministratorRepository
     {
          private readonly UserDbContext _context;

          public AdministratorRepository(UserDbContext context)
          {
               _context = context;
          }

          public async Task<List<AdministratorDTO>> GetAllAdministratorsAsync()
          {
               return await _context.Administrators
                   .Select(a => new AdministratorDTO
                   {
                        UserId = a.Id.Value,
                        Name = a.Name.Value,
                        Email = a.Email.Value,
                        Phone = a.Phone.Value,
                        Cedula = a.Cedula.Value,
                        BirthDate = a.BirthDate.Value.ToString("dd-MM-yyyy")
                   })
                   .ToListAsync();
          }

          public async Task<AdministratorDTO> GetAdministratorByIdAsync(Guid id)
          {
               var admin = await _context.Administrators.FindAsync(new UserId(id));
               if (admin == null)
               {
                    throw new KeyNotFoundException($"Administrator with ID {id} not found.");
               }

               return new AdministratorDTO
               {
                    UserId = admin.Id.Value,
                    Name = admin.Name.Value,
                    Email = admin.Email.Value,
                    Phone = admin.Phone.Value,
                    Cedula = admin.Cedula.Value,
                    BirthDate = admin.BirthDate.Value.ToString("dd-MM-yyyy")
               };
          }

          public async Task<List<AdministratorDTO>> GetAdministratorsByNameAsync(string name)
          {
               var admins = await _context.Administrators
                   .ToListAsync();

               var filteredAdmins = admins
                   .Where(a => a.Name.Value.ToLower().Contains(name.ToLower()))
                   .Select(a => new AdministratorDTO
                   {
                        UserId = a.Id.Value,
                        Name = a.Name.Value,
                        Email = a.Email.Value,
                        Phone = a.Phone.Value,
                        Cedula = a.Cedula.Value,
                        BirthDate = a.BirthDate.Value.ToString("dd-MM-yyyy")
                   })
                   .ToList();

               if (!filteredAdmins.Any())
               {
                    throw new KeyNotFoundException($"No administrators with name containing '{name}' found.");
               }

               return filteredAdmins;
          }

          public async Task AddAdministratorAsync(AdministratorDTO administratorDto)
          {
               var administrator = new Administrator(
                   new UserId(administratorDto.UserId),
                   new UserName(administratorDto.Name),
                   new UserEmail(administratorDto.Email),
                   new UserPhone(administratorDto.Phone),
                   new UserCedula(administratorDto.Cedula),
                   new UserBirthDate(administratorDto.BirthDate)
               );

               _context.Administrators.Add(administrator);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateAdministratorAsync(AdministratorDTO administratorDto)
          {
               var existingAdministrator = await _context.Administrators.FindAsync(new UserId(administratorDto.UserId));
               if (existingAdministrator == null)
               {
                    throw new KeyNotFoundException($"Administrator with ID {administratorDto.UserId} not found.");
               }

               existingAdministrator.ChangeName(new UserName(administratorDto.Name));
               existingAdministrator.ChangePhone(new UserPhone(administratorDto.Phone));
               existingAdministrator.ChangeBirthDate(new UserBirthDate(administratorDto.BirthDate));

               await _context.SaveChangesAsync();
          }
     }
}