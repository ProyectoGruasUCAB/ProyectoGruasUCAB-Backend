namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class WorkerRepository : IWorkerRepository
     {
          private readonly UserDbContext _context;

          public WorkerRepository(UserDbContext context)
          {
               _context = context;
          }

          public async Task<List<WorkerDTO>> GetAllWorkersAsync()
          {
               return await _context.Workers
                   .Select(w => new WorkerDTO
                   {
                        Id = w.Id.Value,
                        Name = w.Name.Value,
                        UserEmail = w.Email.Value,
                        Phone = w.Phone.Value,
                        Cedula = w.Cedula.Value,
                        BirthDate = w.BirthDate.Value.ToString("dd-MM-yyyy"),
                        Position = w.Position.Value
                   })
                   .ToListAsync();
          }

          public async Task<WorkerDTO> GetWorkerByIdAsync(Guid id)
          {
               var worker = await _context.Workers.FindAsync(new UserId(id));
               if (worker == null)
               {
                    throw new KeyNotFoundException($"Worker with ID {id} not found.");
               }

               return new WorkerDTO
               {
                    Id = worker.Id.Value,
                    Name = worker.Name.Value,
                    UserEmail = worker.Email.Value,
                    Phone = worker.Phone.Value,
                    Cedula = worker.Cedula.Value,
                    BirthDate = worker.BirthDate.Value.ToString("dd-MM-yyyy"),
                    Position = worker.Position.Value
               };
          }

          public async Task<List<WorkerDTO>> GetWorkersByNameAsync(string name)
          {
               var workers = await _context.Workers
                   .ToListAsync();

               var filteredWorkers = workers
                   .Where(w => w.Name.Value.ToLower().Contains(name.ToLower()))
                   .Select(w => new WorkerDTO
                   {
                        Id = w.Id.Value,
                        Name = w.Name.Value,
                        UserEmail = w.Email.Value,
                        Phone = w.Phone.Value,
                        Cedula = w.Cedula.Value,
                        BirthDate = w.BirthDate.Value.ToString("dd-MM-yyyy"),
                        Position = w.Position.Value
                   })
                   .ToList();

               if (!filteredWorkers.Any())
               {
                    throw new KeyNotFoundException($"No workers with name containing '{name}' found.");
               }

               return filteredWorkers;
          }

          public async Task<List<WorkerDTO>> GetWorkersByPositionAsync(string position)
          {
               var workers = await _context.Workers
                   .ToListAsync();

               var filteredWorkers = workers
                   .Where(w => w.Position.Value.Equals(position, StringComparison.OrdinalIgnoreCase))
                   .Select(w => new WorkerDTO
                   {
                        Id = w.Id.Value,
                        Name = w.Name.Value,
                        UserEmail = w.Email.Value,
                        Phone = w.Phone.Value,
                        Cedula = w.Cedula.Value,
                        BirthDate = w.BirthDate.Value.ToString("dd-MM-yyyy"),
                        Position = w.Position.Value
                   })
                   .ToList();

               if (!filteredWorkers.Any())
               {
                    throw new KeyNotFoundException($"No workers with position '{position}' found.");
               }

               return filteredWorkers;
          }

          public async Task AddWorkerAsync(WorkerDTO workerDto)
          {
               var worker = new Worker(
                   new UserId(workerDto.Id),
                   new UserName(workerDto.Name),
                   new UserEmail(workerDto.UserEmail),
                   new UserPhone(workerDto.Phone),
                   new UserCedula(workerDto.Cedula),
                   new UserBirthDate(workerDto.BirthDate),
                   new UserPosition(workerDto.Position)
               );

               _context.Workers.Add(worker);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateWorkerAsync(WorkerDTO workerDto)
          {
               var existingWorker = await _context.Workers.FindAsync(new UserId(workerDto.Id));
               if (existingWorker == null)
               {
                    throw new KeyNotFoundException($"Worker with ID {workerDto.Id} not found.");
               }

               existingWorker.ChangeName(new UserName(workerDto.Name));
               existingWorker.ChangePhone(new UserPhone(workerDto.Phone));
               existingWorker.ChangeBirthDate(new UserBirthDate(workerDto.BirthDate));
               existingWorker.ChangePosition(new UserPosition(workerDto.Position));

               await _context.SaveChangesAsync();
          }
     }
}