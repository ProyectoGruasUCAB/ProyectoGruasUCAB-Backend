namespace API_GruasUCAB.ServiceOrder
{
    public static class ServiceOrderServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateServiceOrderService).Assembly);
            services.AddScoped<IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>, CreateServiceOrderService>();
            services.AddScoped<IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>, UpdateServiceOrderService>();
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IServiceOrderFactory, ServiceOrderFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
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

            // SecurityRequestHandlerDecorator for GetAllServiceOrders
            services.Decorate<IRequestHandler<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

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
        }
    }
}