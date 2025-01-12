namespace API_GruasUCAB.ServiceFee
{
     public static class ServiceFeeServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services)
          {
               services.AddMediatR(typeof(CreateServiceFeeCommandHandler).Assembly);
               services.AddScoped<IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>, CreateServiceFeeService>();
               services.AddScoped<IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>, UpdateServiceFeeService>();
               services.AddScoped<IServiceFeeFactory, ServiceFeeFactory>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}