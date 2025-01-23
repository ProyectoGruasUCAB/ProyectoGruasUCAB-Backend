namespace API_GruasUCAB.Auth.Domain.Repositories
{
     public interface INewDriverRepository : IRepository<NewDriver>
     {
          Task<Guid> GetSupplierIdByUserId(Guid userId);
     }
}