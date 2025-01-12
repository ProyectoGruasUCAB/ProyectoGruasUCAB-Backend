
using API_GruasUCAB.Core.Domain.conf;
using API_GruasUCAB.Core.Utilities;
using API_GruasUCAB.Commons.Exceptions;


namespace API_GruasUCAB.Department.Application.Services.CreateDepartment
{
     public class CreateDepartmentService : IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IDepartmentFactory _departmentFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public CreateDepartmentService(IEventStore eventStore, IDepartmentFactory departmentFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _departmentFactory = departmentFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<CreateDepartmentResponseDTO> Execute(CreateDepartmentRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

               var department = _departmentFactory.CreateDepartment(
                   new DepartmentId(Guid.NewGuid()),
                   new DepartmentName(request.Name),
                   new DepartmentDescription(request.Descripcion)
               );

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(department.GetEvents());
               foreach (var domainEvent in department.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

               await _eventStore.AppendEvents(department.Id.ToString(), domainEvents);

               return new CreateDepartmentResponseDTO
               {
                    Success = true,
                    Message = "Department created successfully",
                    UserEmail = request.UserEmail,
                    DepartmentId = department.Id.Id
               };
          }
     }
}