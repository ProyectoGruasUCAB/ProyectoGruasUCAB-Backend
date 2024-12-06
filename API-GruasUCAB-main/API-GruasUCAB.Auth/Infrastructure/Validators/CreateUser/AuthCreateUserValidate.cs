using API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Email;
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Auth.Infrastructure.Adapters.Email;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.PasswordGenerator;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.RoleValidator;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.CreateUser
{
     public class AuthCreateUserValidate : IService<CreateUserRequestDTO, CreateUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<DeleteUserRequestDTO, DeleteUserResponseDTO> _deleteUserService;
          private readonly IService<AssignRoleRequestDTO, AssignRoleResponseDTO> _assignRoleService;
          private readonly EmailProcessor _emailProcessor;
          private readonly RoleValidator _roleValidator;

          public AuthCreateUserValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<DeleteUserRequestDTO, DeleteUserResponseDTO> deleteUserService, IService<AssignRoleRequestDTO, AssignRoleResponseDTO> assignRoleService, EmailProcessor emailProcessor, RoleValidator roleValidator)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
               _deleteUserService = deleteUserService;
               _assignRoleService = assignRoleService;
               _emailProcessor = emailProcessor;
               _roleValidator = roleValidator;
          }

          public async Task<CreateUserResponseDTO> Execute(CreateUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               try
               {
                    // Headers Token
                    var token = _headersToken.GetToken();
                    _headersToken.SetAuthorizationHeader(client);

                    //   Introspect Token
                    var (userCreatorId, role) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    // Validate Role
                    _roleValidator.ValidateCreateUser(role, request.NameRole);

                    // Password Temporary
                    var password = PasswordGenerator.GeneratePassword();

                    // Create User
                    var userCreated = await _keycloakRepository.CreateUserAsync(client, request.Email, password);
                    if (!userCreated)
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Error al crear el usuario", Time = DateTime.UtcNow };
                    }

                    // Email => UserID
                    var (userId, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.Email, string.Empty);

                    // Assign Role
                    var assignRoleResponse = await _assignRoleService.Execute(new AssignRoleRequestDTO
                    {
                         UserId = userId,
                         RoleName = request.NameRole
                    });

                    if (!assignRoleResponse.Success)
                    {
                         var deleteUserResponse = await _deleteUserService.Execute(new DeleteUserRequestDTO { Email = request.Email });
                         if (!deleteUserResponse.Success)
                         {
                              return new CreateUserResponseDTO { Success = false, Message = "Error assigning role and deleting user", Time = DateTime.UtcNow };
                         }
                         return new CreateUserResponseDTO { Success = false, Message = "Error assigning role", Time = DateTime.UtcNow };
                    }

                    //   Send Email
                    var emailResponse = await _emailProcessor.SendEmailAsync(request.Email, "Cuenta creada", "new-user.ftl", new Dictionary<string, string> { { "password", password } });
                    if (!emailResponse.Success)
                    {
                         var deleteUserResponse = await _deleteUserService.Execute(new DeleteUserRequestDTO { Email = request.Email });
                         if (!deleteUserResponse.Success)
                         {
                              return new CreateUserResponseDTO { Success = false, Message = "Error al enviar el correo electrónico y al eliminar el usuario", Time = DateTime.UtcNow };
                         }
                         return new CreateUserResponseDTO { Success = false, Message = emailResponse.Message, Time = DateTime.UtcNow };
                    }


                    Console.WriteLine($"\n\nGenerated password: {password}\n\n");
                    return new CreateUserResponseDTO
                    {
                         Success = true,
                         Message = "User created successfully",
                         UserCreatorId = userCreatorId,
                         UserId = userId,
                         Time = DateTime.UtcNow,
                         Email = request.Email,
                         NameRole = request.NameRole
                    };
               }
               catch (UnauthorizedException ex)
               {
                    return new CreateUserResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new CreateUserResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Time = DateTime.UtcNow
                    };
               }
          }
     }
}