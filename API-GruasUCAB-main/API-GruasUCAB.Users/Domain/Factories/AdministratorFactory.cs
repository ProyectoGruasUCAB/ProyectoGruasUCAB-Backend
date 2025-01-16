namespace API_GruasUCAB.Users.Domain.Factories
{
     public class AdministratorFactory : IAdministratorFactory
     {
          private readonly IAdministratorRepository _administratorRepository;

          public AdministratorFactory(IAdministratorRepository administratorRepository)
          {
               _administratorRepository = administratorRepository;
          }

          public Administrator CreateAdministrator(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate)
          {
               return new Administrator(id, name, email, phone, cedula, birthDate);
          }

          public async Task<Administrator> GetAdministratorById(UserId id)
          {
               var administratorDTO = await _administratorRepository.GetAdministratorByIdAsync(id.Id);
               return new Administrator(
                   new UserId(administratorDTO.UserId),
                   new UserName(administratorDTO.Name),
                   new UserEmail(administratorDTO.Email),
                   new UserPhone(administratorDTO.Phone),
                   new UserCedula(administratorDTO.Cedula),
                   new UserBirthDate(administratorDTO.BirthDate)
               );
          }


     }
}