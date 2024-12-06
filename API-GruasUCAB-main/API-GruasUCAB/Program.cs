using API_GruasUCAB.Auth.Application.Handlers.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Application.Handlers.RecoverPassword;
using API_GruasUCAB.Auth.Application.Handlers.ChangePassword;
using API_GruasUCAB.Auth.Application.Handlers.AssignRole;
using API_GruasUCAB.Auth.Application.Handlers.CreateUser;
using API_GruasUCAB.Auth.Application.Handlers.DeleteUser;
using API_GruasUCAB.Auth.Application.Handlers.Logout;
using API_GruasUCAB.Auth.Application.Handlers.Login;
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.KeycloakRequestBuilder;
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.UrlHelperKeycloak;
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Auth.Infrastructure.Adapters.Email;
using API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
using API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Email;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using API_GruasUCAB.Auth.Infrastructure.Validators.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Infrastructure.Validators.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.Validators.ChangePassword;
using API_GruasUCAB.Auth.Infrastructure.Validators.AssignRole;
using API_GruasUCAB.Auth.Infrastructure.Validators.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.Validators.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.Validators.Logout;
using API_GruasUCAB.Auth.Infrastructure.Validators.Login;
using API_GruasUCAB.Auth.Infrastructure.Validators.Email;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.RoleValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MediatR;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var bearerScheme = builder.Configuration["Keycloak:Auth_Type"];

//  Add Container
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("Sprint-1", new OpenApiInfo { Title = "GruasUCAB", Version = "Alfa" });

    //  JWT
    c.AddSecurityDefinition(bearerScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = bearerScheme
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                Id = bearerScheme
            }
        },
        new string[]{}
    }});
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HeadersToken>();
builder.Services.AddScoped<RoleValidator>();
builder.Services.AddScoped<EmailProcessor>();
builder.Services.AddScoped<SmtpClientFactory>();
builder.Services.AddScoped<EmailTemplateService>();
builder.Services.AddScoped<IHeadersClientCredentialsToken, HeadersClientCredentialsToken>();
builder.Services.AddScoped<IKeycloakRequestBuilder, KeycloakRequestBuilder>();
builder.Services.AddScoped<IUrlHelperKeycloak, UrlHelperKeycloak>();
builder.Services.AddScoped<IKeycloakRepository, KeycloakRepository>();

builder.Services.AddScoped<AuthLoginValidate>();
builder.Services.AddScoped<AuthLogoutValidate>();
builder.Services.AddScoped<AssignRoleValidator>();

builder.Services.AddScoped<IService<LoginRequestDTO, LoginResponseDTO>, AuthLoginValidate>();
builder.Services.AddScoped<IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>, AuthHandleIncompleteAccountValidator>();
builder.Services.AddScoped<IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>, AuthChangePasswordValidator>();
builder.Services.AddScoped<IService<CreateUserRequestDTO, CreateUserResponseDTO>, AuthCreateUserValidate>();
builder.Services.AddScoped<IService<AssignRoleRequestDTO, AssignRoleResponseDTO>, AssignRoleValidator>();
builder.Services.AddScoped<IService<EmailRequestDTO, EmailResponseDTO>, EmailService>();
builder.Services.AddScoped<IService<DeleteUserRequestDTO, DeleteUserResponseDTO>, AuthDeleteUserValidate>();
builder.Services.AddScoped<IService<LogoutRequestDTO, LogoutResponseDTO>, AuthLogoutValidate>();
builder.Services.AddScoped<IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO>, AuthRecoverPasswordValidate>();

builder.Services.AddMediatR(typeof(LoginCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(HandleIncompleteAccountCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(ChangePasswordCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(AssignRoleCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(LogoutCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(RecoverPasswordCommandHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var urlHelperKeycloak = new UrlHelperKeycloak();
        var authorityUrl = urlHelperKeycloak.GetRealmUrl(builder.Configuration);
        options.Authority = authorityUrl;
        options.Audience = builder.Configuration["Keycloak:ClientId"];
        options.RequireHttpsMetadata = builder.Configuration.GetValue<bool>("Keycloak:RequireHttpsMetadata");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = authorityUrl,
            ValidAudience = builder.Configuration["Keycloak:ClientId"]
        };
    });

var app = builder.Build();

//  HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/Sprint-1/swagger.json", "GruasUCAB Sprint-1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();