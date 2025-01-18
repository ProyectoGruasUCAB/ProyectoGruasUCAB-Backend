namespace API_GruasUCAB.Core.Infrastructure.Database
{
    public interface IDbContextTransactionProxy : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
