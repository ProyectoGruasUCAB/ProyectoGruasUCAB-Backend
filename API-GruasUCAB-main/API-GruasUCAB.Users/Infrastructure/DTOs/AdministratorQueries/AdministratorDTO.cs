namespace API_GruasUCAB.Users.Infrastructure.DTOs.AdministratorQueries
{
     public class AdministratorDTO
     {
          public Guid UserId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Email { get; set; } = string.Empty;
          public string Phone { get; set; } = string.Empty;
          public string Cedula { get; set; } = string.Empty;
          public string BirthDate { get; set; } = string.Empty;
     }
}