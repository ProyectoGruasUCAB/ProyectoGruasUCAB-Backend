using Microsoft.Extensions.Configuration;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.UrlHelperKeycloak
{
     public interface IUrlHelperKeycloak
     {
          string GetBaseUrl(IConfiguration configuration);
          string GetRealmUrl(IConfiguration configuration);
          string GetAdminUrl(IConfiguration configuration);
          string GetTokenUrl(IConfiguration configuration);
          string GetIntrospectUrl(IConfiguration configuration);
          string GetUserEndpoint(IConfiguration configuration);
          string GetUserByEmailUrl(IConfiguration configuration, string email);
          string GetUserByIdEndpoint(IConfiguration configuration, string userId);
          string GetResetPasswordEndpoint(IConfiguration configuration, string userId);
          string GetRoleMappingsEndpoint(IConfiguration configuration, string userId, string clientId);
          string GetClientsEndpoint(IConfiguration configuration);
          string GetClientRolesEndpoint(IConfiguration configuration, string clientId);
          string GetLogoutUrl(IConfiguration configuration);
     }
}