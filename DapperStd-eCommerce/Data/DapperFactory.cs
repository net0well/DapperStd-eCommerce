using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperStd_eCommerce.Data
{
    public class DapperFactory : IDapperFactory
    {
        private readonly string _connectionString;

        public DapperFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
