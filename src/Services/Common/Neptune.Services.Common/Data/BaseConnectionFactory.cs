using System.Data;
using System.Data.SqlClient;

namespace Neptune.Services.Common.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Open();
    }

    public abstract class BaseConnectionFactory : IConnectionFactory
    {
        public IDbConnection Open()
        {
            var connection = new SqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        private string GetConnectionString()
        {
            var host = "sql";
            var username = "sa";
            var password = "Password123%";
            var database = GetDatabaseName();
            return $"Server={host};Database={database};User id={username};Password={password};MultipleActiveResultSets=true";
        }

        public abstract string GetDatabaseName();
    }
}
