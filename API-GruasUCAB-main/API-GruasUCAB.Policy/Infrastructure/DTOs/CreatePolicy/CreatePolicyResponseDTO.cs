namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreatePolicy
{
     public class CreatePolicyResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid PolicyId { get; set; }

          [JsonPropertyOrder(2)]
          public int Number { get; set; }
     }
}