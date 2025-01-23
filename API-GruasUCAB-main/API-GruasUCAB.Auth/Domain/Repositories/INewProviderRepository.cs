namespace API_GruasUCAB.Auth.Domain.Repositories
{
     public interface INewProviderRepository : IRepository<NewProvider>
     {
          Task<Guid?> GetSupplierIdByUserId(Guid userId);
     }
}