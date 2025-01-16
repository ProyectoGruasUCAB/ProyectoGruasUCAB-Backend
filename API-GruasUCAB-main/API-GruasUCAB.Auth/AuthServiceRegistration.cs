namespace API_GruasUCAB.Auth
{
     public static class AuthServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
          {
               // Keycloak Configuration
               var configurationBuilder = new ConfigurationBuilder()
                   .AddConfiguration(configuration);

               var keycloakConfigFile = configuration["Keycloak:ConfigFile"];
               if (!string.IsNullOrEmpty(keycloakConfigFile))
               {
                    configurationBuilder.AddJsonFile(keycloakConfigFile, optional: false, reloadOnChange: true);
               }

               var builtConfiguration = configurationBuilder.Build();

               services.AddKeycloakWebApiAuthentication(builtConfiguration, options =>
               {
                    options.RequireHttpsMetadata = false;
                    options.Authority = new UrlHelperKeycloak().GetRealmUrl(builtConfiguration);
                    options.Audience = builtConfiguration["Keycloak:ClientId"];
               });

               // Auth
               services.AddAuthorization();
               services.AddScoped<HeadersToken>();
               services.AddScoped<EmailProcessor>();
               services.AddScoped<AuthLoginValidate>();
               services.AddScoped<SmtpClientFactory>();
               services.AddScoped<AuthLogoutValidate>();
               services.AddScoped<AssignRoleValidator>();
               services.AddScoped<EmailTemplateService>();
               services.AddMediatR(typeof(LoginCommandHandler).Assembly);
               services.AddMediatR(typeof(LogoutCommandHandler).Assembly);
               services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
               services.AddMediatR(typeof(AssignRoleCommandHandler).Assembly);
               services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
               services.AddMediatR(typeof(RefreshTokenCommandHandler).Assembly);
               services.AddMediatR(typeof(ChangePasswordCommandHandler).Assembly);
               services.AddMediatR(typeof(RecoverPasswordCommandHandler).Assembly);
               services.AddMediatR(typeof(HandleIncompleteAccountCommandHandler).Assembly);
               services.AddScoped<IUrlHelperKeycloak, UrlHelperKeycloak>();
               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddScoped<IKeycloakRequestBuilder, KeycloakRequestBuilder>();
               services.AddScoped<IHeadersClientCredentialsToken, HeadersClientCredentialsToken>();
               services.AddScoped<IService<EmailRequestDTO, EmailResponseDTO>, EmailService>();
               services.AddScoped<IService<LoginRequestDTO, LoginResponseDTO>, AuthLoginValidate>();
               services.AddScoped<IService<LogoutRequestDTO, LogoutResponseDTO>, AuthLogoutValidate>();
               services.AddScoped<IService<AssignRoleRequestDTO, AssignRoleResponseDTO>, AssignRoleValidator>();
               services.AddScoped<IService<CreateUserRequestDTO, CreateUserResponseDTO>, AuthCreateUserValidate>();
               services.AddScoped<IService<DeleteUserRequestDTO, DeleteUserResponseDTO>, AuthDeleteUserValidate>();
               services.AddScoped<IService<RefreshTokenRequestDTO, RefreshTokenResponseDTO>, AuthRefreshTokenValidate>();
               services.AddScoped<IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>, AuthChangePasswordValidator>();
               services.AddScoped<IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO>, AuthRecoverPasswordValidate>();
               services.AddScoped<IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>, AuthHandleIncompleteAccountValidator>();

               // Decorators
               services.Decorate<IService<CreateUserRequestDTO, CreateUserResponseDTO>>(
                   (inner, provider) => new RoleValidationDecorator<CreateUserRequestDTO, CreateUserResponseDTO>(
                       inner,
                       provider.GetRequiredService<IKeycloakRepository>(),
                       provider.GetRequiredService<IHttpClientFactory>(),
                       provider.GetRequiredService<IHttpContextAccessor>()));
          }
     }
}