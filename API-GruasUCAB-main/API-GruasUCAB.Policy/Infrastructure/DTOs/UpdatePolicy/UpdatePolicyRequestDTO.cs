namespace API_GruasUCAB.Policy.Infrastructure.DTOs.UpdatePolicy
{
     public class UpdatePolicyRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Policy ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid PolicyId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Descripcion { get; set; } = string.Empty;
     }
}