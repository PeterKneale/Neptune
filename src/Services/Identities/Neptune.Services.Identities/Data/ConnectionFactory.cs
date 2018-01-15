using Neptune.Services.Common.Data;

namespace Neptune.Services.Identities.Data
{
    public class ConnectionFactory : BaseConnectionFactory, IConnectionFactory
    {
        public override string GetDatabaseName()
        {
            return "Identities";
        }
    }
}
