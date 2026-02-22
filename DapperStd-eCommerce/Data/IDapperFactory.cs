using System.Data;

namespace DapperStd_eCommerce.Data
{
    public interface IDapperFactory
    {
        IDbConnection CreateConnection();
    }
}
