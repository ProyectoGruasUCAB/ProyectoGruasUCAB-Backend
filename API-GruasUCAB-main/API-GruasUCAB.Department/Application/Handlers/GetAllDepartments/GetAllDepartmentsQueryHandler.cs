namespace API_GruasUCAB.Department.Application.Handlers.GetAllDepartments
{
     public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, GetAllDepartmentsResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;

          public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
          {
               _departmentRepository = departmentRepository;
          }

          public async Task<GetAllDepartmentsResponseDTO> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
          {
               var departments = await _departmentRepository.GetAllDepartmentsAsync();
               return new GetAllDepartmentsResponseDTO { Departments = departments };
          }
     }
}