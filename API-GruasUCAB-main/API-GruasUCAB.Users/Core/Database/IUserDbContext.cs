using API_GruasUCAB.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_GruasUCAB.Users.Core.Database
{
    public interface IUserDbContext
    {
        DbContext DbContext { get; }

        //DbSet<User> Users { get; set; }

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}