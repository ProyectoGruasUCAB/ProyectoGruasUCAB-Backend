using Microsoft.EntityFrameworkCore;

namespace API_GruasUCAB.Auth.Infrastructure.Repositories
{
     public class NewWorkerRepository : Repository<NewWorker>, INewWorkerRepository
     {
          public NewWorkerRepository(AuthDbContext context) : base(context)
          {
          }

          public async Task<(Guid DepartmentId, string Position)?> GetDepartmentAndPositionByUserId(Guid userId)
          {
               var worker = await _context.NewWorkers.FirstOrDefaultAsync(w => w.WorkerId == userId);
               if (worker == null)
               {
                    throw new Exception("DepartmentId and Position not found for the given UserId");
               }
               return (worker.DepartmentId, worker.Position);
          }
     }
}