namespace API_GruasUCAB.Users.Domain.Factories
{
     public interface IProviderFactory
     {
          Provider CreateProvider(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              SupplierId supplierId);

          Task<Provider> GetProviderById(UserId id);
     }
}