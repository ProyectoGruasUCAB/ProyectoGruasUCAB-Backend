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
     }
}