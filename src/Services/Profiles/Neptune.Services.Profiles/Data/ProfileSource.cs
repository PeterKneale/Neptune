using Neptune.Services.Common;
using Neptune.Services.Common.Data;
using System;
using System.Data;

namespace Neptune.Services.Profiles.Data
{
    public interface IProfileSource : IDataSource<ProfileData, Guid>
    {

    }
    public class ProfileSource : BaseDataSource<ProfileData, Guid>, IProfileSource
    {
        public ProfileSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }
    }
}
