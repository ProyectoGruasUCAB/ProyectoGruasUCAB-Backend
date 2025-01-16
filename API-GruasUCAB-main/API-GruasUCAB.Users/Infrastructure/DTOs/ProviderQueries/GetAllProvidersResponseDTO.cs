namespace API_GruasUCAB.Users.Infrastructure.DTOs.ProviderQueries
{
     public class GetAllProvidersResponseDTO
     {
          public List<ProviderDTO> Providers { get; set; } = new List<ProviderDTO>();
     }
}