using API_GruasUCAB.Core.Domain.conf;
using API_GruasUCAB.Users.Infrastructure.EventStore;

namespace API_GruasUCAB.Department
{
     public static class DepartmentServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services)
          {
               services.AddMediatR(typeof(CreateDepartmentCommandHandler).Assembly);
               services.AddScoped<IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>, CreateDepartmentService>();
               services.AddScoped<IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>, UpdateDepartmentService>();
               services.AddScoped<IDepartmentFactory, DepartmentFactory>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}