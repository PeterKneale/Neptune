using Neptune.Services.Common.Data;

namespace Neptune.Services.Profiles.Data
{
    public interface IProfileUnitOfWork : IUnitOfWork
    {
        IProfileSource Profiles { get; }
    }

    public class UnitOfWork : BaseUnitOfWork, IProfileUnitOfWork
    {
        private IProfileSource _threads;

        public UnitOfWork(IConnectionFactory factory) : base(factory)
        {
        }

        public IProfileSource Profiles
        {
            get { return _threads ?? (_threads = new ProfileSource(Connection, Transaction)); }
        }
    }
}
