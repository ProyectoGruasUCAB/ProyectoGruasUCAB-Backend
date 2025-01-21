namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreateClient
{
    public class CreateClientRequestDTO : BaseRequestDTO
    {
        [Required(ErrorMessage = "User ID is required.")]
        [JsonPropertyOrder(2)]
        public Guid Id_cliente { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [JsonPropertyOrder(2)]
        public string Nombre_completo_cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cedula is required.")]
        [JsonPropertyOrder(2)]
        public int Cedula_cliente { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [JsonPropertyOrder(2)]
        public int Tlf_cliente { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [JsonPropertyOrder(2)]
        public DateTime Fecha_nacimiento_cliente { get; set; }


    }
}