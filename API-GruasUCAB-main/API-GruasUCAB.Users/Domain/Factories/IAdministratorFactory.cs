namespace API_GruasUCAB.Users.Domain.Factories
{
     public interface IAdministratorFactory
     {
          Administrator CreateAdministrator(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate);

          Task<Administrator> GetAdministratorById(UserId id);

     }
}