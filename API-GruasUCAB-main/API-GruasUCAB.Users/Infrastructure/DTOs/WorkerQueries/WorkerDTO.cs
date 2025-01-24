namespace API_GruasUCAB.Users.Infrastructure.DTOs.WorkerQueries
{
     public class WorkerDTO
     {
          public Guid Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string UserEmail { get; set; } = string.Empty;
          public string Phone { get; set; } = string.Empty;
          public string Cedula { get; set; } = string.Empty;
          public string BirthDate { get; set; } = string.Empty;
          public string Position { get; set; } = string.Empty;
          public Guid DepartmentId { get; set; }
     }
}