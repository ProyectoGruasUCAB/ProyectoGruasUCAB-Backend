namespace API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount
{
     public class IncompleteAccountResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public bool TemporaryPassword { get; set; }
     }
}