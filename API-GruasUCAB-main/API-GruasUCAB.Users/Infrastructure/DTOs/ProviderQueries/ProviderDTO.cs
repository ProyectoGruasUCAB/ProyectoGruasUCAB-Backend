namespace API_GruasUCAB.Users.Infrastructure.DTOs.ProviderQueries
{
     public class ProviderDTO
     {
          public string UserEmail { get; set; } = string.Empty;
          public Guid Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Phone { get; set; } = string.Empty;
          public string Cedula { get; set; } = string.Empty;
          public string BirthDate { get; set; } = string.Empty;
     }
}