namespace API_GruasUCAB.Department.Application.Exceptions
{
     public class DepartmentNotFoundException : Exception
     {
          public DepartmentNotFoundException(Guid departmentId)
              : base($"Department with ID {departmentId} not found.")
          {
          }
     }
}