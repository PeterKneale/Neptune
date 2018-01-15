using Neptune.Services.Common.Data;

namespace Neptune.Services.Identities.Data
{
    public interface IIdentityUnitOfWork : IUnitOfWork
    {
        IUserSource Users { get; }
    }

    public class UnitOfWork : BaseUnitOfWork, IIdentityUnitOfWork
    {
        private IUserSource _threads;

        public UnitOfWork(IConnectionFactory factory) : base(factory)
        {
        }

        public IUserSource Users
        {
            get { return _threads ?? (_threads = new UserSource(Connection, Transaction)); }
        }
    }
}
