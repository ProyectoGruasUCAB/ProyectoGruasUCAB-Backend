namespace API_GruasUCAB.Users.Application.Services.Auth
{
     public interface IAuthService
     {
          Task<(string UserId, string Role, string Email)> IntrospectTokenAsync(string token);
     }
}