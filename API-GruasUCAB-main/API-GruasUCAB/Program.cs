using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Application.Command.CreateUser;
using API_GruasUCAB.Auth.Application.Command.AssignRole;
using API_GruasUCAB.Auth.Application.Command.ChangePassword;
using API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Application.Command.DeleteUser;
using API_GruasUCAB.Auth.Application.Command.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Auth.Infrastructure.Providers;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.ClientCredentials;
using API_GruasUCAB.Core.Infrastructure.RoleVerifier;
using API_GruasUCAB.Core.Infrastructure.KeycloakRequestBuilder;
using API_GruasUCAB.Core.Infrastructure.UrlHelperKeycloak;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var bearerScheme = builder.Configuration["Keycloak:Auth_Type"];

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("Sprint-1", new OpenApiInfo { Title = "GruasUCAB", Version = "Alfa" });

    // Configurar el esquema de seguridad JWT
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
builder.Services.AddScoped<RoleVerifier>();
builder.Services.AddScoped<IHeadersClientCredentialsToken, HeadersClientCredentialsToken>();
builder.Services.AddScoped<IKeycloakRequestBuilder, KeycloakRequestBuilder>();
builder.Services.AddScoped<IUrlHelperKeycloak, UrlHelperKeycloak>();
builder.Services.AddScoped<IKeycloakRepository, KeycloakRepository>();

builder.Services.AddScoped<AuthLoginValidate>();
builder.Services.AddScoped<AuthLogoutValidate>();

builder.Services.AddScoped<IService<LoginRequestDTO, LoginResponseDTO>, AuthLoginValidate>();
builder.Services.AddScoped<IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>, AuthHandleIncompleteAccountValidator>();
builder.Services.AddScoped<IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>, ChangePasswordValidator>();
builder.Services.AddScoped<IService<CreateUserRequestDTO, CreateUserResponseDTO>, AuthCreateUserValidate>();
builder.Services.AddScoped<IService<AssignRoleRequestDTO, AssignRoleResponseDTO>, AssignRoleValidator>();
builder.Services.AddScoped<IService<EmailRequestDTO, EmailResponseDTO>, EmailService>();
builder.Services.AddScoped<IService<DeleteUserRequestDTO, DeleteUserResponseDTO>, AuthDeleteUserValidate>();
builder.Services.AddScoped<IService<LogoutRequestDTO, LogoutResponseDTO>, AuthLogoutValidate>();
builder.Services.AddScoped<IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO>, AuthRecoverPasswordValidate>();

// Register MediatR
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

// Configure the HTTP request pipeline.
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