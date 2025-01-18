namespace API_GruasUCAB.Core.Infrastructure.Database
{
    public interface IUserDbContext
    {
        DbContext DbContext { get; }

        IDbContextTransaction BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}