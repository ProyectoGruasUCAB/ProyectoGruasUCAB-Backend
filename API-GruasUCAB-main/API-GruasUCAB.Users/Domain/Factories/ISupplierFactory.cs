namespace API_GruasUCAB.Users.Domain.Factories
{
     public interface ISupplierFactory
     {
          Supplier CreateSupplier(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate);
<<<<<<< HEAD

          Task<Supplier> GetSupplierById(UserId id);
=======
>>>>>>> origin/Development
     }
}