using API_GruasUCAB.Core.Domain.conf;
using API_GruasUCAB.Users.Infrastructure.EventStore;

namespace API_GruasUCAB.Vehicle
{
     public static class VehicleServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services)
          {
               services.AddMediatR(typeof(CreateVehicleCommandHandler).Assembly);
               services.AddScoped<IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>, CreateVehicleService>();
               services.AddScoped<IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>, UpdateVehicleService>();
               services.AddScoped<IVehicleFactory, VehicleFactory>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}