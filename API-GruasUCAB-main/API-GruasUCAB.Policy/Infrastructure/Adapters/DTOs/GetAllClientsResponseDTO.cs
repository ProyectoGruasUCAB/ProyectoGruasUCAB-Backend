namespace API_GruasUCAB.Policy.Infrastructure.Adapters.DTOs
{
     public class GetAllClientsResponseDTO
     {
          public List<ClientDTO> Clients { get; set; } = new List<ClientDTO>();
     }
}