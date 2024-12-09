namespace API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword
{
    public class ChangePasswordResponseDTO : BaseResponseDTO
    {
        [Required]
        [JsonPropertyOrder(2)]
        public bool TemporaryPassword { get; set; }
    }
}