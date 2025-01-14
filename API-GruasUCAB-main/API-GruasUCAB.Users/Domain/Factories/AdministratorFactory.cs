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

          public async Task<Administrator> GetAdministratorById(UserId id)
          {
               // Implementa la lógica para obtener el administrador por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new Administrator(
                   id,
                   new UserName("Example Name"),
                   new UserEmail("example@example.com"),
                   new UserPhone("04240000000"),
                   new UserCedula("V-12345678"),
                   new UserBirthDate("01-01-2000")
               ));
          }
     }
}