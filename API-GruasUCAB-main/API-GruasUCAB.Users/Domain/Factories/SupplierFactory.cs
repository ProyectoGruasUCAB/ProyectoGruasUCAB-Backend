namespace API_GruasUCAB.Users.Domain.Factories
{
     public class SupplierFactory : ISupplierFactory
     {
          private readonly IProviderRepository _providerRepository;

          public SupplierFactory(IProviderRepository providerRepository)
          {
               _providerRepository = providerRepository;
          }

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
               var providerDTO = await _providerRepository.GetProviderByIdAsync(id.Id);
               return new Supplier(
                   new UserId(providerDTO.Id),
                   new UserName(providerDTO.Name),
                   new UserEmail(providerDTO.UserEmail),
                   new UserPhone(providerDTO.Phone),
                   new UserCedula(providerDTO.Cedula),
                   new UserBirthDate(providerDTO.BirthDate)
               );
          }
     }
}