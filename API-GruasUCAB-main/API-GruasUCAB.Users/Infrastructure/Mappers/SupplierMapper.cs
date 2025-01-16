namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public static class SupplierMapper
     {
          public static ProviderDTO ToDTO(this Supplier supplier)
          {
               return new ProviderDTO
               {
                    Id = supplier.Id.Id,
                    Name = supplier.Name.Value,
                    UserEmail = supplier.Email.Value,
                    Phone = supplier.Phone.Value,
                    Cedula = supplier.Cedula.Value,
                    BirthDate = supplier.BirthDate.Value.ToString("dd-MM-yyyy")
               };
          }
     }
}