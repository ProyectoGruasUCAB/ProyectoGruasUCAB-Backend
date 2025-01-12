using API_GruasUCAB.Auth;
using API_GruasUCAB.Core;
using API_GruasUCAB.Swagger;
using API_GruasUCAB.Core.Utilities.Logger;
<<<<<<< HEAD
using API_GruasUCAB.Users;
=======
using Serilog;
>>>>>>> origin/Development

var builder = WebApplication.CreateBuilder(args);

//   Configurar Serilog
CoreServiceRegistration.ConfigureLogging(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
AuthServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
<<<<<<< HEAD
UserServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
=======
CoreServiceRegistration.RegisterServices(builder.Services, builder.Configuration);

// Configurar Swagger
>>>>>>> origin/Development
builder.Services.AddSwaggerConfiguration(builder.Configuration);

var app = builder.Build();

<<<<<<< HEAD
CoreServiceRegistration.UseLogging(app);
app.UseSwaggerUIConfiguration(app.Environment, builder.Configuration);
app.UseMiddleware<BearerTokenMiddleware>();
=======
//   Serilog
CoreServiceRegistration.UseLogging(app);

//   Swagger
app.UseSwaggerUIConfiguration(app.Environment, builder.Configuration);
app.UseMiddleware<BearerTokenMiddleware>();

>>>>>>> origin/Development
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.RunLogger();