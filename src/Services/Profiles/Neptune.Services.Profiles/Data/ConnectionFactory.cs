using Neptune.Services.Common.Data;

namespace Neptune.Services.Profiles.Data
{
    public class ConnectionFactory : BaseConnectionFactory, IConnectionFactory
    {
        public override string GetConnectionString()
        {
            return "Server=.;Database=profiles;User id=sa;Password=password;MultipleActiveResultSets=true";
        }
    }
}
