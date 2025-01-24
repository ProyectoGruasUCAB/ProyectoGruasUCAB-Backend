namespace API_GruasUCAB.Auth.Domain.Repositories
{
     public interface INewWorkerRepository : IRepository<NewWorker>
     {
          Task<(Guid DepartmentId, string Position)?> GetDepartmentAndPositionByUserId(Guid userId);
     }
}