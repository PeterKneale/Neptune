using Neptune.Services.Common.Data;

namespace Neptune.Services.Profiles.Data
{
    public class ConnectionFactory : BaseConnectionFactory, IConnectionFactory
    {
        public override string GetConnectionString()
        {
            var host = "sql";
            var username = "sa";
            var password = "Password123%";
            return $"Server={host};Database=profiles;User id={username};Password={password};MultipleActiveResultSets=true";
        }
    }
}
