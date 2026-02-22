namespace DapperStd_eCommerce.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
