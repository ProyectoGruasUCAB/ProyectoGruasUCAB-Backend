namespace API_GruasUCAB.Auth.Domain.Entities
{
     public class NewWorker
     {
          public Guid WorkerId { get; set; }
          public Guid DepartmentId { get; set; }
          public string Position { get; set; } = null!;
     }
}