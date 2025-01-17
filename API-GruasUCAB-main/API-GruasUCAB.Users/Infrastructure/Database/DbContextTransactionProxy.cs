using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using API_GruasUCAB.Users.Infrastructure.Database;
using API_GruasUCAB.Users.Core.Database;

namespace API_GruasUCAB.Users.Infrastructure.Database
{
    public class DbContextTransactionProxy : IDbContextTransactionProxy
    {

        private readonly IDbContextTransaction _transaction;

        private bool _disposed;

        public DbContextTransactionProxy(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
