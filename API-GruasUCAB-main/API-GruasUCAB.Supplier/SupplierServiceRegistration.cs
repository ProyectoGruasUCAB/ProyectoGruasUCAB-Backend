namespace API_GruasUCAB.Supplier
{
    public static class SupplierServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SupplierDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(SupplierProfile));

            services.AddMediatR(typeof(CreateSupplierCommandHandler).Assembly);
            services.AddScoped<IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>, CreateSupplierService>();
            services.AddScoped<IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>, UpdateSupplierService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierFactory, SupplierFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            // Queries
            services.AddScoped<IRequestHandler<GetAllSuppliersQuery, GetAllSuppliersResponseDTO>, GetAllSuppliersQueryHandler>();
            services.AddScoped<IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdResponseDTO>, GetSupplierByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetSupplierByTypeQuery, GetSupplierByTypeResponseDTO>, GetSupplierByTypeQueryHandler>();
            services.AddScoped<IRequestHandler<GetSupplierByNameQuery, GetSupplierByNameResponseDTO>, GetSupplierByNameQueryHandler>();

            // SecurityDecorator
            services.Decorate<IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateSupplierRequestDTO, CreateSupplierResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador","Proveedor"));

            services.Decorate<IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            // SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllSuppliersQuery, GetAllSuppliersResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllSuppliersQuery, GetAllSuppliersResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor", "Conductor"));

            services.Decorate<IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetSupplierByIdQuery, GetSupplierByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Proveedor"));

            services.Decorate<IRequestHandler<GetSupplierByTypeQuery, GetSupplierByTypeResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetSupplierByTypeQuery, GetSupplierByTypeResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));

            services.Decorate<IRequestHandler<GetSupplierByNameQuery, GetSupplierByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetSupplierByNameQuery, GetSupplierByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador"));
        }
    }
}