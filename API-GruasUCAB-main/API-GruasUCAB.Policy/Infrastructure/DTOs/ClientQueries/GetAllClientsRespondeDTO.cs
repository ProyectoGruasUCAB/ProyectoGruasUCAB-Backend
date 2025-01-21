namespace API_GruasUCAB.Policy.Infrastructure.DTOs.ClientQueries
{
    public class GetAllClientsResponseDTO
    {
        public List<ClientDTO> Clients { get; set; } = new List<ClientDTO>();
    }
}