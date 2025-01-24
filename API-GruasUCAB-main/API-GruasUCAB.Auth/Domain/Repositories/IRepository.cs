namespace API_GruasUCAB.Auth.Domain.Repositories
{
     public interface IRepository<T> where T : class
     {
          Task Add(T entity);
          Task<T?> GetById(Guid id);
     }
}