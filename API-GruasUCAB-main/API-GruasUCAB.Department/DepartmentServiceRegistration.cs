namespace API_GruasUCAB.Department
{
    public static class DepartmentServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateDepartmentCommandHandler).Assembly);
            services.AddScoped<IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>, CreateDepartmentService>();
            services.AddScoped<IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>, UpdateDepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentFactory, DepartmentFactory>();
            services.AddScoped<IEventStore, InMemoryEventStore>();
            services.AddScoped<IKeycloakRepository, KeycloakRepository>();
            services.AddHttpClient();

            //  Queries
            services.AddScoped<IRequestHandler<GetAllDepartmentsQuery, GetAllDepartmentsResponseDTO>, GetAllDepartmentsQueryHandler>();
            services.AddScoped<IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdResponseDTO>, GetDepartmentByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDepartmentByNameQuery, GetDepartmentByNameResponseDTO>, GetDepartmentByNameQueryHandler>();

            //  SecurityDecorator
            services.Decorate<IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>>(
                (inner, provider) => new SecurityDecorator<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>>(
                (inner, provider) => new SecurityDecorator<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            //  SecurityRequestHandlerDecorator
            services.Decorate<IRequestHandler<GetAllDepartmentsQuery, GetAllDepartmentsResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetAllDepartmentsQuery, GetAllDepartmentsResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDepartmentByIdQuery, GetDepartmentByIdResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));

            services.Decorate<IRequestHandler<GetDepartmentByNameQuery, GetDepartmentByNameResponseDTO>>(
                (inner, provider) => new SecurityRequestHandlerDecorator<GetDepartmentByNameQuery, GetDepartmentByNameResponseDTO>(
                    inner,
                    provider.GetRequiredService<IKeycloakRepository>(),
                    provider.GetRequiredService<IHttpClientFactory>(),
                    provider.GetRequiredService<IHttpContextAccessor>(),
                    "Administrador", "Trabajador"));
        }
    }
}