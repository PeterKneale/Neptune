using Neptune.Services.Common.Data;
using System;
using System.Data;

namespace Neptune.Services.Questions.Data
{
    public interface IQuestionSource : IDataSource<QuestionData, Guid>
    {

    }

    public class QuestionSource : BaseDataSource<QuestionData, Guid>, IQuestionSource
    {
        public QuestionSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }
    }
}
