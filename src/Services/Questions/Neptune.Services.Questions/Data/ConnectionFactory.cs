using Neptune.Services.Common.Data;

namespace Neptune.Services.Questions.Data
{
    public class ConnectionFactory : BaseConnectionFactory, IConnectionFactory
    {
        public override string GetDatabaseName()
        {
            return "questions";
        }
    }
}
