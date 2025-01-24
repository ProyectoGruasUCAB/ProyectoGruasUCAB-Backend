namespace API_GruasUCAB.Users.Infrastructure.DTOs.WorkerQueries
{
     public class GetWorkersByNameResponseDTO
     {
          public List<WorkerDTO> Workers { get; set; } = new List<WorkerDTO>();
     }
}