using API_GruasUCAB.Auth;
using API_GruasUCAB.Users;
using API_GruasUCAB.ServiceFee;
using API_GruasUCAB.Department;
using API_GruasUCAB.Supplier;
using API_GruasUCAB.Vehicle;
using API_GruasUCAB.Policy;
using API_GruasUCAB.ServiceOrder;
using API_GruasUCAB.Core;
using API_GruasUCAB.Core.Utilities.Logger;
using API_GruasUCAB.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
CoreServiceRegistration.ConfigureLogging(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
AuthServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
UserServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
ServiceFeeServiceRegistration.RegisterServices(builder.Services);
DepartmentServiceRegistration.RegisterServices(builder.Services);
SupplierServiceRegistration.RegisterServices(builder.Services);
VehicleServiceRegistration.RegisterServices(builder.Services);
PolicyServiceRegistration.RegisterServices(builder.Services);
ServiceOrderServiceRegistration.RegisterServices(builder.Services);

// Agregar YARP
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Configurar Swagger
builder.Services.AddSwaggerConfiguration(builder.Configuration);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurar Serilog
CoreServiceRegistration.UseLogging(app);

// Configurar Swagger
app.UseSwaggerUIConfiguration(app.Environment, builder.Configuration);

// Usar Middleware de Autenticación y Autorización
app.UseMiddleware<BearerTokenMiddleware>();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapReverseProxy();

app.RunLogger();
