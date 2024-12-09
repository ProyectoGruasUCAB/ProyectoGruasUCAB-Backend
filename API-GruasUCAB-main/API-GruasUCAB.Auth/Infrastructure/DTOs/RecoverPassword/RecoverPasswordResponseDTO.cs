namespace API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword
{
     public class RecoverPasswordResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public bool TemporaryPassword { get; set; }
     }
}