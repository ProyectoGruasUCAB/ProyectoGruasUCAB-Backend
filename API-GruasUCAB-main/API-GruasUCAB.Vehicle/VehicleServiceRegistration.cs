namespace API_GruasUCAB.Vehicle
{
    public static class VehicleServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<VehicleDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(VehicleProfile), typeof(VehicleTypeProfile));

            services.AddMediatR(typeof(CreateVehicleCommandHandler).Assembly);
            services.AddScoped<IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>, CreateVehicleService>();
            services.AddScoped<IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>, UpdateVehicleService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleFactory, VehicleFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            // VehicleType Services
            services.AddScoped<IService<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO>, CreateVehicleTypeService>();
            services.AddScoped<IService<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO>, UpdateVehicleTypeService>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IVehicleTypeFactory, VehicleTypeFactory>();

            // Queries
            services.AddScoped<IRequestHandler<GetAllVehiclesQuery, GetAllVehiclesResponseDTO>, GetAllVehiclesQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdResponseDTO>, GetVehicleByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleByLicensePlateQuery, GetVehicleByLicensePlateResponseDTO>, GetVehicleByLicensePlateQueryHandler>();

            // VehicleType Queries
            services.AddScoped<IRequestHandler<GetAllVehicleTypesQuery, GetAllVehicleTypesResponseDTO>, GetAllVehicleTypesQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleTypeByIdQuery, GetVehicleTypeByIdResponseDTO>, GetVehicleTypeByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetVehicleTypeByNameQuery, GetVehicleTypeByNameResponseDTO>, GetVehicleTypeByNameQueryHandler>();

            // SecurityDecorator
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

            // VehicleType SecurityDecorator
            services.Decorate<IService<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IService<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            // SecurityRequestHandlerDecorator
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

            // VehicleType SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllVehicleTypesQuery, GetAllVehicleTypesResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllVehicleTypesQuery, GetAllVehicleTypesResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetVehicleTypeByIdQuery, GetVehicleTypeByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetVehicleTypeByIdQuery, GetVehicleTypeByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetVehicleTypeByNameQuery, GetVehicleTypeByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetVehicleTypeByNameQuery, GetVehicleTypeByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));
        }
    }
}