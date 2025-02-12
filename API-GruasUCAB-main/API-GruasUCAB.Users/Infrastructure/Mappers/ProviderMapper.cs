namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public static class ProviderMapper
     {
          public static ProviderDTO ToDTO(this Provider provider)
          {
               return new ProviderDTO
               {
                    Id = provider.Id.Id,
                    Name = provider.Name.Value,
                    UserEmail = provider.Email.Value,
                    Phone = provider.Phone.Value,
                    Cedula = provider.Cedula.Value,
                    BirthDate = provider.BirthDate.Value.ToString("dd-MM-yyyy"),
                    SupplierId = provider.SupplierId.Id
               };
          }

          public static Provider ToEntity(this ProviderDTO providerDTO)
          {
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