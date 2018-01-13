using Neptune.Services.Common.Data;

namespace Neptune.Services.Questions.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory<IQuestionUnitOfWork>
    {
        private readonly IConnectionFactory _factory;

        public UnitOfWorkFactory(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public IQuestionUnitOfWork Begin()
        {
            return new UnitOfWork(_factory);
        }
    }
}
