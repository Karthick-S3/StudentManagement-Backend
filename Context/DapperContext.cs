using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentManagement.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DapConnection");


        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
