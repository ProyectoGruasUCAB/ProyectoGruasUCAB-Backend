namespace API_GruasUCAB.Users.Domain.Factories
{
     public class AdministratorFactory : IAdministratorFactory
     {
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
     }
}