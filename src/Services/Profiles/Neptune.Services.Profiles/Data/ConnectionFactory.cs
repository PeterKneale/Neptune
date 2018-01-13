using Neptune.Services.Common.Data;

namespace Neptune.Services.Profiles.Data
{
    public class ConnectionFactory : BaseConnectionFactory, IConnectionFactory
    {
        public override string GetDatabaseName()
        {
            return "profiles";
        }
    }
}
