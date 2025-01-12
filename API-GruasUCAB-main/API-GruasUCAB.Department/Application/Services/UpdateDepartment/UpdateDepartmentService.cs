namespace API_GruasUCAB.Department.Application.Services.UpdateDepartment
{
     public class UpdateDepartmentService : IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IDepartmentFactory _departmentFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public UpdateDepartmentService(IEventStore eventStore, IDepartmentFactory departmentFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _departmentFactory = departmentFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<UpdateDepartmentResponseDTO> Execute(UpdateDepartmentRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador" && role != "Trabajador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

               var department = await _departmentFactory.GetDepartmentById(new DepartmentId(request.DepartmentId));
               if (department == null)
               {
                    throw new DepartmentNotFoundException(request.DepartmentId);
               }

               if (!string.IsNullOrEmpty(request.Name))
               {
                    department.ChangeName(new DepartmentName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Descripcion))
               {
                    department.ChangeDescription(new DepartmentDescription(request.Descripcion));
               }

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(department.GetEvents());
               foreach (var domainEvent in department.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

               await _eventStore.AppendEvents(department.Id.ToString(), domainEvents);

               return new UpdateDepartmentResponseDTO
               {
                    Success = true,
                    Message = "Department updated successfully",
                    UserEmail = request.UserEmail,
                    DepartmentId = department.Id.Id,
                    Name = department.Name.Value,
                    Descripcion = department.Description.Value
               };
          }
     }
}