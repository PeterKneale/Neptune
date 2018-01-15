using Dapper;
using Neptune.Services.Common.Data;
using System;
using System.Data;
using System.Threading.Tasks;
using DB = Neptune.Services.Identities.Database.DatabaseSchema;

namespace Neptune.Services.Identities.Data
{
    public interface IUserSource : IDataSource<UserData, Guid>
    {
        Task<UserData> GetByEmail(string email);
        Task<UserData> GetByUserName(string userName);
    }

    public class UserSource : BaseDataSource<UserData, Guid>, IUserSource
    {
        public UserSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }
        
        public async Task<UserData> GetByEmail(string email)
        {
            var query = $"select * from {DB.TableUser} where {DB.ColumnEmail} = @email";
            return await Connection.QueryFirstOrDefaultAsync<UserData>(query, new { email }, Transaction);
        }

        public async Task<UserData> GetByUserName(string username)
        {
            var query = $"select * from {DB.TableUser} where {DB.ColumnUserName} = @username";
            return await Connection.QueryFirstOrDefaultAsync<UserData>(query, new { username }, Transaction);
        }
    }
}
