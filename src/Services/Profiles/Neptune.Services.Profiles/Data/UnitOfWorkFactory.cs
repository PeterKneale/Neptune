using Neptune.Services.Common.Data;

namespace Neptune.Services.Profiles.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory<IProfileUnitOfWork>
    {
        private readonly IConnectionFactory _factory;

        public UnitOfWorkFactory(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public IProfileUnitOfWork Begin()
        {
            return new UnitOfWork(_factory);
        }
    }
}
