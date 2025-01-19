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
     }
}