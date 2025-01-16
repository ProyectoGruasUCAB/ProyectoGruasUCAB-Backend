namespace API_GruasUCAB.Policy.Infrastructure.DTOs.UpdatePolicy
{
     public class UpdatePolicyResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid PolicyId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;
     }
}