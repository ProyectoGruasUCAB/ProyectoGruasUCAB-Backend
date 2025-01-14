namespace API_GruasUCAB.Users
{
     public static class UserServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services)
          {
               services.AddMediatR(typeof(RecordUserDataCommandHandler).Assembly);
               services.AddScoped<IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>, RecordUserDataService>();
               services.AddScoped<IAdministratorFactory, AdministratorFactory>();
               services.AddScoped<IDriverFactory, DriverFactory>();
               services.AddScoped<IWorkerFactory, WorkerFactory>();
               services.AddScoped<ISupplierFactory, SupplierFactory>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>, UpdateRecordUserDataService>();

               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}