using System.Collections.Generic;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRequestBuilder.DTO
{
    public class KeycloakRequestDTO
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? GrantType { get; set; }
        public bool? EmailVerified { get; set; }
        public bool? Enabled { get; set; }
        public List<Dictionary<string, object>> Credentials { get; set; } = new List<Dictionary<string, object>>();
    }
}