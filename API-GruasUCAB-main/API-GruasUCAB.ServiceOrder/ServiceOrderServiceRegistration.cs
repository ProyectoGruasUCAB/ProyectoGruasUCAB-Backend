namespace API_GruasUCAB.ServiceOrder
{
    public static class ServiceOrderServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<ServiceOrderDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Registrar MediatR
            services.AddMediatR(typeof(CreateServiceOrderCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateServiceOrderCommandHandler).Assembly);

            // Registrar servicios
            services.AddScoped<IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>, CreateServiceOrderService>();
            services.AddScoped<IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>, UpdateServiceOrderService>();

            // Registrar repositorios
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IServiceOrderFactory, ServiceOrderFactory>();
            services.AddScoped<IncidentCostCalculator>();

            // Registrar otros servicios necesarios
            services.AddHttpClient();

            // SecurityDecorator for CreateServiceOrder
            services.Decorate<IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityDecorator for UpdateServiceOrder
            services.Decorate<IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // Queries
            services.AddScoped<IRequestHandler<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>, GetAllServiceOrdersQueryHandler>();
            services.AddScoped<IRequestHandler<GetServiceOrderByIdQuery, GetServiceOrderByIdResponseDTO>, GetServiceOrderByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetServiceOrdersByStatusQuery, GetServiceOrdersByStatusResponseDTO>, GetServiceOrdersByStatusQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersByDriverIdQuery, GetOrdersByDriverIdResponseDTO>, GetOrdersByDriverIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersByVehicleIdQuery, GetOrdersByVehicleIdResponseDTO>, GetOrdersByVehicleIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersByOperatorIdQuery, GetOrdersByOperatorIdResponseDTO>, GetOrdersByOperatorIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersBySupplierIdQuery, GetOrdersBySupplierIdResponseDTO>, GetOrdersBySupplierIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersByClientIdQuery, GetOrdersByClientIdResponseDTO>, GetOrdersByClientIdQueryHandler>();

            // SecurityRequestHandlerDecorator for GetAllServiceOrders
            services.Decorate<IRequestHandler<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador", "Proveedor"));

            // SecurityRequestHandlerDecorator for GetServiceOrderById
            services.Decorate<IRequestHandler<GetServiceOrderByIdQuery, GetServiceOrderByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetServiceOrderByIdQuery, GetServiceOrderByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetServiceOrdersByStatus
            services.Decorate<IRequestHandler<GetServiceOrdersByStatusQuery, GetServiceOrdersByStatusResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetServiceOrdersByStatusQuery, GetServiceOrdersByStatusResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetOrdersByDriverId
            services.Decorate<IRequestHandler<GetOrdersByDriverIdQuery, GetOrdersByDriverIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetOrdersByDriverIdQuery, GetOrdersByDriverIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetOrdersByVehicleId
            services.Decorate<IRequestHandler<GetOrdersByVehicleIdQuery, GetOrdersByVehicleIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetOrdersByVehicleIdQuery, GetOrdersByVehicleIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetOrdersByOperatorId
            services.Decorate<IRequestHandler<GetOrdersByOperatorIdQuery, GetOrdersByOperatorIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetOrdersByOperatorIdQuery, GetOrdersByOperatorIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetOrdersBySupplierId
            services.Decorate<IRequestHandler<GetOrdersBySupplierIdQuery, GetOrdersBySupplierIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetOrdersBySupplierIdQuery, GetOrdersBySupplierIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator for GetOrdersByClientId
            services.Decorate<IRequestHandler<GetOrdersByClientIdQuery, GetOrdersByClientIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetOrdersByClientIdQuery, GetOrdersByClientIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));
        }
    }
}