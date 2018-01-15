using Neptune.Services.Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using DB = Neptune.Services.Questions.Database.DatabaseSchema;

namespace Neptune.Services.Questions.Data
{
    public interface IAnswerSource : IDataSource<AnswerData, Guid>
    {
        Task<IEnumerable<AnswerData>> ListByQuestion(Guid id);
    }

    public class AnswerSource : BaseDataSource<AnswerData, Guid>, IAnswerSource
    {
        public AnswerSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }

        public async Task<IEnumerable<AnswerData>> ListByQuestion(Guid id)
        {
            var query = $"select * from {DB.TableAnswer} where {DB.ColumnQuestionId} = @id";
            return await Connection.GetListAsync<AnswerData>(query, new { id }, Transaction);
        }
    }
}
