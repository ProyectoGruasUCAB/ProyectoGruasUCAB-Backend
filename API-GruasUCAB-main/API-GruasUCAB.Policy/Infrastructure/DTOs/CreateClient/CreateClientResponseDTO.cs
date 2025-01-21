namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreateClient
{
    public class CreateClientResponseDTO : BaseResponseDTO
    {
        [JsonPropertyOrder(2)]
        public Guid Id_cliente { get; set; }
    }
}