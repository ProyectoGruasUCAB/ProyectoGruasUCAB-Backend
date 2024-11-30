using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRepository
{
     public class TokenResponse
     {
          [Required]
          public string AccessToken { get; set; } = string.Empty;
          public string RefreshToken { get; set; } = string.Empty;
     }
}