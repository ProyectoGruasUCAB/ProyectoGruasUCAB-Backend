namespace API_GruasUCAB.ServiceFee
{
    public static class ServiceFeeServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateServiceFeeCommandHandler).Assembly);
            services.AddScoped<IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>, CreateServiceFeeService>();
            services.AddScoped<IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>, UpdateServiceFeeService>();
            services.AddScoped<IServiceFeeRepository, ServiceFeeRepository>();
            services.AddScoped<IServiceFeeFactory, ServiceFeeFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            //  Queries
            services.AddScoped<IRequestHandler<GetAllServiceFeesQuery, GetAllServiceFeesResponseDTO>, GetAllServiceFeesQueryHandler>();
            services.AddScoped<IRequestHandler<GetServiceFeeByIdQuery, GetServiceFeeByIdResponseDTO>, GetServiceFeeByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetServiceFeeByNameQuery, GetServiceFeeByNameResponseDTO>, GetServiceFeeByNameQueryHandler>();

            //  SecurityDecorator
            services.Decorate<IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            //  SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllServiceFeesQuery, GetAllServiceFeesResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllServiceFeesQuery, GetAllServiceFeesResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetServiceFeeByIdQuery, GetServiceFeeByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetServiceFeeByIdQuery, GetServiceFeeByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetServiceFeeByNameQuery, GetServiceFeeByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetServiceFeeByNameQuery, GetServiceFeeByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));
        }
    }
}