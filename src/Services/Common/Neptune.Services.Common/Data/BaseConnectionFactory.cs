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

        public abstract string GetConnectionString();
    }
}
