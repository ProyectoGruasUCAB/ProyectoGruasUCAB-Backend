namespace API_GruasUCAB.Users.Domain.Factories
{
     public class ProviderFactory : IProviderFactory
     {
          private readonly IProviderRepository _providerRepository;

          public ProviderFactory(IProviderRepository providerRepository)
          {
               _providerRepository = providerRepository;
          }

          public Provider CreateProvider(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              SupplierId supplierId)
          {
               return new Provider(id, name, email, phone, cedula, birthDate, supplierId);
          }

          public async Task<Provider> GetProviderById(UserId id)
          {
               var providerDTO = await _providerRepository.GetProviderByIdAsync(id.Id);
               return new Provider(
                   new UserId(providerDTO.Id),
                   new UserName(providerDTO.Name),
                   new UserEmail(providerDTO.UserEmail),
                   new UserPhone(providerDTO.Phone),
                   new UserCedula(providerDTO.Cedula),
                   new UserBirthDate(providerDTO.BirthDate),
                   new SupplierId(providerDTO.SupplierId)
               );
          }
     }
}