namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class WorkerRepository : IWorkerRepository
     {
          private readonly List<WorkerDTO> _workers;

          public WorkerRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _workers = new List<WorkerDTO>
            {
                new WorkerDTO
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Worker1",
                    UserEmail = "worker1@example.com",
                    Phone = "1234567890",
                    Cedula = "12345678",
                    BirthDate = "01-01-2000",
                    Position = "Position1"
                },
                new WorkerDTO
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Worker2",
                    UserEmail = "worker2@example.com",
                    Phone = "0987654321",
                    Cedula = "87654321",
                    BirthDate = "01-01-2000",
                    Position = "Position2"
                },
                new WorkerDTO
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Worker3",
                    UserEmail = "worker3@example.com",
                    Phone = "1122334455",
                    Cedula = "11223344",
                    BirthDate = "01-01-2000",
                    Position = "Position3"
                }
            };
          }

          public async Task<List<WorkerDTO>> GetAllWorkersAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_workers);
          }

          public async Task<WorkerDTO> GetWorkerByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var worker = _workers.FirstOrDefault(w => w.Id == id);
               if (worker == null)
               {
                    throw new KeyNotFoundException($"Worker with ID {id} not found.");
               }
               return await Task.FromResult(worker);
          }

          public async Task<List<WorkerDTO>> GetWorkersByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var workers = _workers.Where(w => w.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!workers.Any())
               {
                    throw new KeyNotFoundException($"No workers with name containing '{name}' found.");
               }
               return await Task.FromResult(workers);
          }

          public async Task<List<WorkerDTO>> GetWorkersByPositionAsync(string position)
          {
               // Simulación de una llamada a la base de datos
               var workers = _workers.Where(w => w.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!workers.Any())
               {
                    throw new KeyNotFoundException($"No workers with position '{position}' found.");
               }
               return await Task.FromResult(workers);
          }

          public async Task AddWorkerAsync(WorkerDTO worker)
          {
               // Simulación de una llamada a la base de datos
               _workers.Add(worker);
               await Task.CompletedTask;
          }

          public async Task UpdateWorkerAsync(WorkerDTO worker)
          {
               // Simulación de una llamada a la base de datos
               var existingWorker = _workers.FirstOrDefault(w => w.Id == worker.Id);
               if (existingWorker == null)
               {
                    throw new KeyNotFoundException($"Worker with ID {worker.Id} not found.");
               }

               existingWorker.Name = worker.Name;
               existingWorker.UserEmail = worker.UserEmail;
               existingWorker.Phone = worker.Phone;
               existingWorker.Cedula = worker.Cedula;
               existingWorker.BirthDate = worker.BirthDate;
               existingWorker.Position = worker.Position;

               await Task.CompletedTask;
          }
     }
}