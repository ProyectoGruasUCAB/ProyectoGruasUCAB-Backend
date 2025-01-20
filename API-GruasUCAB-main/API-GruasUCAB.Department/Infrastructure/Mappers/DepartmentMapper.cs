namespace API_GruasUCAB.Department.Infrastructure.Mappers
{
     public static class DepartmentMapper
     {
          public static DepartmentDTO ToDTO(this Domain.AggregateRoot.Department department)
          {
               return new DepartmentDTO
               {
                    DepartmentId = department.Id.Value,
                    Name = department.Name.Value,
                    Descripcion = department.Description.Value
               };
          }

          public static Domain.AggregateRoot.Department ToEntity(this DepartmentDTO departmentDto)
          {
               return new Domain.AggregateRoot.Department(
                   new DepartmentId(departmentDto.DepartmentId),
                   new DepartmentName(departmentDto.Name),
                   new DepartmentDescription(departmentDto.Descripcion)
               );
          }
     }
}