namespace API_GruasUCAB.Supplier
{
     public static class SupplierServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services)
          {
               services.AddMediatR(typeof(CreateSupplierCommandHandler).Assembly);
               services.AddScoped<IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>, CreateSupplierService>();
               services.AddScoped<IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>, UpdateSupplierService>();
               services.AddScoped<ISupplierFactory, SupplierFactory>();
               services.AddScoped<IEventStore, InMemoryEventStore>();
               services.AddScoped<IKeycloakRepository, KeycloakRepository>();
               services.AddHttpClient();
          }
     }
}