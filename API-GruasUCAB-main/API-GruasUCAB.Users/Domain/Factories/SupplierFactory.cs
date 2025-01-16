namespace API_GruasUCAB.Users.Domain.Factories
{
     public class SupplierFactory : ISupplierFactory
     {
          public Supplier CreateSupplier(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate)
          {
               return new Supplier(id, name, email, phone, cedula, birthDate);
          }

          public async Task<Supplier> GetSupplierById(UserId id)
          {
               // Implementa la lógica para obtener el proveedor por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new Supplier(
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