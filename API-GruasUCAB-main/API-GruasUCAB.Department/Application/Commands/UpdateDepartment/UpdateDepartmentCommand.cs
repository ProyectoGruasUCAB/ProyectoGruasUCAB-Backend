namespace API_GruasUCAB.Department.Application.Commands.UpdateDepartment
{
     public class UpdateDepartmentCommand : IRequest<UpdateDepartmentResponseDTO>
     {
          public UpdateDepartmentRequestDTO UpdateDepartmentRequestDTO { get; set; }

          public UpdateDepartmentCommand(UpdateDepartmentRequestDTO updateDepartmentRequestDTO)
          {
               UpdateDepartmentRequestDTO = updateDepartmentRequestDTO;
          }
     }
}