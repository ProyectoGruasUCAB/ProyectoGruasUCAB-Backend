namespace API_GruasUCAB.Users
{
     public static class UserServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
          {
               services.AddScoped<IUserFactory, UserFactory>();
               services.AddMediatR(typeof(RecordUserDataCommandHandler).Assembly);
               services.AddScoped<IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>, RecordUserDataService>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>, UpdateRecordUserDataService>();

               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}