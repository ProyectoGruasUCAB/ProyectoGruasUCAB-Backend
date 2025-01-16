namespace API_GruasUCAB.Users
{
<<<<<<< HEAD
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
=======
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
>>>>>>> origin/Development

            // Repositorios
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();

            //  Queries
            services.AddScoped<IRequestHandler<GetAllAdministratorsQuery, GetAllAdministratorsResponseDTO>, GetAllAdministratorsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdministratorByIdQuery, GetAdministratorByIdResponseDTO>, GetAdministratorByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdministratorsByNameQuery, GetAdministratorsByNameResponseDTO>, GetAdministratorsByNameQueryHandler>();

            services.AddScoped<IRequestHandler<GetAllDriversQuery, GetAllDriversResponseDTO>, GetAllDriversQueryHandler>();
            services.AddScoped<IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponseDTO>, GetDriverByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDriversByNameQuery, GetDriversByNameResponseDTO>, GetDriversByNameQueryHandler>();

            //  SecurityDecorator
            services.Decorate<IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>>(
                (inner, provider) => new RecordUserDataSecurityDecorator<RecordUserDataRequestDTO, RecordUserDataResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>()));

            services.Decorate<IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>>(
                (inner, provider) => new RecordUserDataSecurityDecorator<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>()));

            //  SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllAdministratorsQuery, GetAllAdministratorsResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllAdministratorsQuery, GetAllAdministratorsResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            services.Decorate<IRequestHandler<GetAdministratorByIdQuery, GetAdministratorByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAdministratorByIdQuery, GetAdministratorByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            services.Decorate<IRequestHandler<GetAdministratorsByNameQuery, GetAdministratorsByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAdministratorsByNameQuery, GetAdministratorsByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            services.Decorate<IRequestHandler<GetAllDriversQuery, GetAllDriversResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllDriversQuery, GetAllDriversResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            services.Decorate<IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDriverByIdQuery, GetDriverByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetDriversByNameQuery, GetDriversByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDriversByNameQuery, GetDriversByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));
        }
    }
}