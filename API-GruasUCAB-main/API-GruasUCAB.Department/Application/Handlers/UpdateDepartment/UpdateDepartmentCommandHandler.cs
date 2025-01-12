namespace API_GruasUCAB.Department.Application.Handlers.UpdateDepartment
{
     public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentResponseDTO>
     {
          private readonly IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO> _updateDepartmentService;

          public UpdateDepartmentCommandHandler(IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO> updateDepartmentService)
          {
               _updateDepartmentService = updateDepartmentService;
          }

          public async Task<UpdateDepartmentResponseDTO> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
          {
               return await _updateDepartmentService.Execute(request.UpdateDepartmentRequestDTO);
          }
     }
}