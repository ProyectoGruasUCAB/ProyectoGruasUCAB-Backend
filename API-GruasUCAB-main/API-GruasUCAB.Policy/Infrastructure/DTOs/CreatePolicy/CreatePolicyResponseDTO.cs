namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreatePolicy
{
     public class CreatePolicyResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid PolicyId { get; set; }
     }
}