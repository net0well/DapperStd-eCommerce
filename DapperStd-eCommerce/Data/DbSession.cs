using Microsoft.Data.SqlClient;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperStd_eCommerce.Data
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection("Server=localhost,1433;Database=dapperStd-Commerce;User Id=sa;Password=Str0ngP@ssword!;TrustServerCertificate=True;Encrypt=False;");
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
