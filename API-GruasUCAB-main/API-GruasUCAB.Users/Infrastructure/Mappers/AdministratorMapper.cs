namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public static class AdministratorMapper
     {
          public static AdministratorDTO ToDTO(this Administrator administrator)
          {
               return new AdministratorDTO
               {
                    UserId = administrator.Id.Id,
                    Name = administrator.Name.Value,
                    Email = administrator.Email.Value,
                    Phone = administrator.Phone.Value,
                    Cedula = administrator.Cedula.Value,
                    BirthDate = administrator.BirthDate.Value.ToString("dd-MM-yyyy")
               };
          }
     }
}