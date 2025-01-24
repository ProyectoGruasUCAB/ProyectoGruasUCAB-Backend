namespace API_GruasUCAB.Department.Application.Handlers.GetDepartmentByName
{
     public class GetDepartmentByNameQueryHandler : IRequestHandler<GetDepartmentByNameQuery, GetDepartmentByNameResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;

          public GetDepartmentByNameQueryHandler(IDepartmentRepository departmentRepository)
          {
               _departmentRepository = departmentRepository;
          }

          public async Task<GetDepartmentByNameResponseDTO> Handle(GetDepartmentByNameQuery request, CancellationToken cancellationToken)
          {
               var department = await _departmentRepository.GetDepartmentByNameAsync(request.Name);
               return new GetDepartmentByNameResponseDTO { Department = department };
          }
     }
}