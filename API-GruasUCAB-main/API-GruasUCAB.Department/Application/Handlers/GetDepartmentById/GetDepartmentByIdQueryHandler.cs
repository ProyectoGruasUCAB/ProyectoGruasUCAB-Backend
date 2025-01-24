namespace API_GruasUCAB.Department.Application.Handlers.GetDepartmentById
{
     public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;

          public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
          {
               _departmentRepository = departmentRepository;
          }

          public async Task<GetDepartmentByIdResponseDTO> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
          {
               var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
               return new GetDepartmentByIdResponseDTO { Department = department };
          }
     }
}