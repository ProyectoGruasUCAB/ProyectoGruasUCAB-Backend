using API_GruasUCAB.Auth;
using API_GruasUCAB.Core;
using API_GruasUCAB.Swagger;
using API_GruasUCAB.Core.Utilities.Logger;
using API_GruasUCAB.Users;

var builder = WebApplication.CreateBuilder(args);

//   Configurar Serilog
CoreServiceRegistration.ConfigureLogging(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
AuthServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
UserServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
builder.Services.AddSwaggerConfiguration(builder.Configuration);

var app = builder.Build();

CoreServiceRegistration.UseLogging(app);
app.UseSwaggerUIConfiguration(app.Environment, builder.Configuration);
app.UseMiddleware<BearerTokenMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.RunLogger();