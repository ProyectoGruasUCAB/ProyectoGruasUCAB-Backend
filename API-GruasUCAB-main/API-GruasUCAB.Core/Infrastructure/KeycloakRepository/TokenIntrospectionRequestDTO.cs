using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRepository
{
     public class TokenIntrospectionRequestDTO
     {
          [Required]
          public string Token { get; set; } = string.Empty;
          public string ExpectedTokenType { get; set; } = string.Empty;
     }
}