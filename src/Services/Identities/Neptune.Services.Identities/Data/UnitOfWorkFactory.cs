using Neptune.Services.Common.Data;

namespace Neptune.Services.Identities.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory<IIdentityUnitOfWork>
    {
        private readonly IConnectionFactory _factory;

        public UnitOfWorkFactory(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public IIdentityUnitOfWork Begin()
        {
            return new UnitOfWork(_factory);
        }
    }
}
