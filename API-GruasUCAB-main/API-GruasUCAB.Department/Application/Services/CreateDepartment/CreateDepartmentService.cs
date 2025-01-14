namespace API_GruasUCAB.Department.Application.Services.CreateDepartment
{
     public class CreateDepartmentService : IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IDepartmentFactory _departmentFactory;

          public CreateDepartmentService(IEventStore eventStore, IDepartmentFactory departmentFactory)
          {
               _eventStore = eventStore;
               _departmentFactory = departmentFactory;
          }

          public async Task<CreateDepartmentResponseDTO> Execute(CreateDepartmentRequestDTO request)
          {
               var department = _departmentFactory.CreateDepartment(
                   new DepartmentId(Guid.NewGuid()),
                   new DepartmentName(request.Name),
                   new DepartmentDescription(request.Descripcion)
               );

               var domainEvents = new List<IDomainEvent>(department.GetEvents());

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