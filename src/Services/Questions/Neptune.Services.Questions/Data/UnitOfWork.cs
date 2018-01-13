using Neptune.Services.Common.Data;

namespace Neptune.Services.Questions.Data
{
    public interface IQuestionUnitOfWork : IUnitOfWork
    {
        IQuestionSource Questions { get; }
    }

    public class UnitOfWork : BaseUnitOfWork, IQuestionUnitOfWork
    {
        private IQuestionSource _threads;

        public UnitOfWork(IConnectionFactory factory) : base(factory)
        {
        }

        public IQuestionSource Questions
        {
            get { return _threads ?? (_threads = new QuestionSource(Connection, Transaction)); }
        }
    }
}
