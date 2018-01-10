using Neptune.Services.Common;
using Neptune.Services.Common.Data;
using System.Data;

namespace Neptune.Services.Profiles.Data
{
    public interface IProfileSource : IDataSource<ProfileData, int>
    {

    }
    public class ProfileSource : BaseDataSource<ProfileData, int>, IProfileSource
    {
        public ProfileSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }
    }
}
