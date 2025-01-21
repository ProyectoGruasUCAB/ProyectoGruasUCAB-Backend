namespace API_GruasUCAB.Policy
{
    public static class PolicyServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Configurar DbContext
            services.AddDbContext<PolicyDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            services.AddMediatR(typeof(CreatePolicyService).Assembly);
            services.AddScoped<IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO>, CreatePolicyService>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IPolicyFactory, PolicyFactory>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            // Queries
            services.AddScoped<IRequestHandler<GetAllPoliciesQuery, GetAllPoliciesResponseDTO>, GetAllPoliciesQueryHandler>();
            services.AddScoped<IRequestHandler<GetPolicyByIdQuery, GetPolicyByIdResponseDTO>, GetPolicyByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetPolicyByPolicyNumberQuery, GetPolicyByPolicyNumberResponseDTO>, GetPolicyByPolicyNumberQueryHandler>();

            // SecurityDecorator
            services.Decorate<IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreatePolicyRequestDTO, CreatePolicyResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            // SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllPoliciesQuery, GetAllPoliciesResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllPoliciesQuery, GetAllPoliciesResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetPolicyByIdQuery, GetPolicyByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetPolicyByIdQuery, GetPolicyByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetPolicyByPolicyNumberQuery, GetPolicyByPolicyNumberResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetPolicyByPolicyNumberQuery, GetPolicyByPolicyNumberResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));
        }
    }
}