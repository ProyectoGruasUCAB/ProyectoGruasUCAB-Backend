namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public static class WorkerMapper
     {
          public static WorkerDTO ToDTO(this Worker worker)
          {
               return new WorkerDTO
               {
                    Id = worker.Id.Id,
                    Name = worker.Name.Value,
                    UserEmail = worker.Email.Value,
                    Phone = worker.Phone.Value,
                    Cedula = worker.Cedula.Value,
                    BirthDate = worker.BirthDate.Value.ToString("dd-MM-yyyy"),
                    Position = worker.Position.Value,
                    DepartmentId = worker.DepartmentId.Id
               };
          }
     }
}