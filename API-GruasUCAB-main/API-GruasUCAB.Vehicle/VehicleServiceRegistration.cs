namespace API_GruasUCAB.Vehicle
{
    public static class VehicleServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateVehicleCommandHandler).Assembly);
            services.AddScoped<IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>, CreateVehicleService>();
            services.AddScoped<IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>, UpdateVehicleService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleFactory, VehicleFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            //  Queries
            services.AddScoped<IRequestHandler<GetAllVehiclesQuery, GetAllVehiclesResponseDTO>, GetAllVehiclesQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdResponseDTO>, GetVehicleByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleByLicensePlateQuery, GetVehicleByLicensePlateResponseDTO>, GetVehicleByLicensePlateQueryHandler>();

            //  SecurityDecorator
            services.Decorate<IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateVehicleRequestDTO, CreateVehicleResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            //  SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllVehiclesQuery, GetAllVehiclesResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllVehiclesQuery, GetAllVehiclesResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetVehicleByIdQuery, GetVehicleByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetVehicleByLicensePlateQuery, GetVehicleByLicensePlateResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetVehicleByLicensePlateQuery, GetVehicleByLicensePlateResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));
        }
    }
}