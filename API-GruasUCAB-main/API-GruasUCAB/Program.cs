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
builder.Services.AddScoped<IHeadersClientCredentialsToken, HeadersClientCredentialsToken>();
builder.Services.AddScoped<IKeycloakRequestBuilder, KeycloakRequestBuilder>();
builder.Services.AddScoped<IUrlHelperKeycloak, UrlHelperKeycloak>();
builder.Services.AddScoped<IKeycloakRepository, KeycloakRepository>();

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