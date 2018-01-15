using Neptune.Services.Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using DB = Neptune.Services.Questions.Database.DatabaseSchema;

namespace Neptune.Services.Questions.Data
{
    public interface IQuestionSource : IDataSource<QuestionData, Guid>
    {
        Task<int> CountAnswers(Guid id);
        Task<int> CountVotes(Guid id);
        Task<int> CountStars(Guid id);
    }

    public class QuestionSource : BaseDataSource<QuestionData, Guid>, IQuestionSource
    {
        public QuestionSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }

        public Task<int> CountAnswers(Guid id)
        {
            return Connection.QuerySingleAsync<int>($"select count(1) from {DB.TableAnswer} where {DB.ColumnQuestionId} = @id", new { id=id.ToString() });
        }

        public Task<int> CountStars(Guid id)
        {
            return Connection.QuerySingleAsync<int>($"select count(1) from {DB.TableQuestionStars} where {DB.ColumnQuestionId} = @id", new { id = id.ToString() });
        }

        public Task<int> CountVotes(Guid id)
        {
            return Connection.QuerySingleAsync<int>($"select count(1) from {DB.TableQuestionVotes} where {DB.ColumnQuestionId} = @id", new { id = id.ToString() });
        }
    }
}
