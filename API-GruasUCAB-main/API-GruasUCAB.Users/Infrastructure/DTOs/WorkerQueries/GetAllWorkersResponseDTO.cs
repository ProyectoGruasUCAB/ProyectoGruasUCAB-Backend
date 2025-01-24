namespace API_GruasUCAB.Users.Infrastructure.DTOs.WorkerQueries
{
     public class GetAllWorkersResponseDTO
     {
          public List<WorkerDTO> Workers { get; set; } = new List<WorkerDTO>();
     }
}