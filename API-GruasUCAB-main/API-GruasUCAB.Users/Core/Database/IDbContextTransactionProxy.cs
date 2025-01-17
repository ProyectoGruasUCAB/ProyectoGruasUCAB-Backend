namespace API_GruasUCAB.Users.Core.Database
{
    public interface IDbContextTransactionProxy : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
