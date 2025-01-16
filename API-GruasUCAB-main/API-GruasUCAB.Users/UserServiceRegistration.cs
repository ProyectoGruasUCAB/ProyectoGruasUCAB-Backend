namespace API_GruasUCAB.Users
{
    public static class UserServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(RecordUserDataCommandHandler).Assembly);
            services.AddScoped<IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>, RecordUserDataService>();
            services.AddScoped<IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>, UpdateRecordUserDataService>();

            // Factories
            services.AddScoped<IAdministratorFactory, AdministratorFactory>();
            services.AddScoped<IDriverFactory, DriverFactory>();
            services.AddScoped<IWorkerFactory, WorkerFactory>();
            services.AddScoped<ISupplierFactory, SupplierFactory>();


            services.AddScoped<IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>, UpdateRecordUserDataService>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();


            // Repositories
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();

            // Record User Data Services
            services.AddScoped<IRecordAdministratorData, RecordAdministratorData>();
            services.AddScoped<IRecordDriverData, RecordDriverData>();
            services.AddScoped<IRecordWorkerData, RecordWorkerData>();
            services.AddScoped<IRecordSupplierData, RecordSupplierData>();

            // Update User Data Services
            services.AddScoped<IUpdateRecordAdministratorData, UpdateRecordAdministratorData>();
            services.AddScoped<IUpdateRecordDriverData, UpdateRecordDriverData>();
            services.AddScoped<IUpdateRecordWorkerData, UpdateRecordWorkerData>();
            services.AddScoped<IUpdateRecordSupplierData, UpdateRecordSupplierData>();

            // Queries
            services.AddScoped<IRequestHandler<GetAllAdministratorsQuery, GetAllAdministratorsResponseDTO>, GetAllAdministratorsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdministratorByIdQuery, GetAdministratorByIdResponseDTO>, GetAdministratorByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdministratorsByNameQuery, GetAdministratorsByNameResponseDTO>, GetAdministratorsByNameQueryHandler>();

            services.AddScoped<IRequestHandler<GetAllDriversQuery, GetAllDriversResponseDTO>, GetAllDriversQueryHandler>();
            services.AddScoped<IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponseDTO>, GetDriverByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDriversByNameQuery, GetDriversByNameResponseDTO>, GetDriversByNameQueryHandler>();

            services.AddScoped<IRequestHandler<GetAllWorkersQuery, GetAllWorkersResponseDTO>, GetAllWorkersQueryHandler>();
            services.AddScoped<IRequestHandler<GetWorkerByIdQuery, GetWorkerByIdResponseDTO>, GetWorkerByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetWorkersByNameQuery, GetWorkersByNameResponseDTO>, GetWorkersByNameQueryHandler>();
            services.AddScoped<IRequestHandler<GetWorkersByPositionQuery, GetWorkersByPositionResponseDTO>, GetWorkersByPositionQueryHandler>();

            services.AddScoped<IRequestHandler<GetAllProvidersQuery, GetAllProvidersResponseDTO>, GetAllProvidersQueryHandler>();
            services.AddScoped<IRequestHandler<GetProviderByIdQuery, GetProviderByIdResponseDTO>, GetProviderByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetProvidersByNameQuery, GetProvidersByNameResponseDTO>, GetProvidersByNameQueryHandler>();

            services.AddHttpClient();

            /*
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
                    "Administrador", "Proveedor", "Trabajador"));

            services.Decorate<IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDriverByIdQuery, GetDriverByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor", "Trabajador"));

            services.Decorate<IRequestHandler<GetDriversByNameQuery, GetDriversByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDriversByNameQuery, GetDriversByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor", "Trabajador"));

            services.Decorate<IRequestHandler<GetAllWorkersQuery, GetAllWorkersResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllWorkersQuery, GetAllWorkersResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetWorkerByIdQuery, GetWorkerByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetWorkerByIdQuery, GetWorkerByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetWorkersByNameQuery, GetWorkersByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetWorkersByNameQuery, GetWorkersByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetWorkersByPositionQuery, GetWorkersByPositionResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetWorkersByPositionQuery, GetWorkersByPositionResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetAllProvidersQuery, GetAllProvidersResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllProvidersQuery, GetAllProvidersResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetProviderByIdQuery, GetProviderByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetProviderByIdQuery, GetProviderByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetProvidersByNameQuery, GetProvidersByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetProvidersByNameQuery, GetProvidersByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));
            */
        }
    }
}