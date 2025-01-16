namespace API_GruasUCAB.Users.Domain.Repositories
{
     public interface IWorkerRepository
     {
          Task<List<WorkerDTO>> GetAllWorkersAsync();
          Task<WorkerDTO> GetWorkerByIdAsync(Guid id);
          Task<List<WorkerDTO>> GetWorkersByNameAsync(string name);
          Task<List<WorkerDTO>> GetWorkersByPositionAsync(string position);
          Task AddWorkerAsync(WorkerDTO worker);
          Task UpdateWorkerAsync(WorkerDTO worker);
     }
}