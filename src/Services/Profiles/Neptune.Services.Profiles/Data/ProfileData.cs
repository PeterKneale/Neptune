using Dapper;
using Neptune.Services.Common.Data;
using Neptune.Services.Profiles.Database;

namespace Neptune.Services.Profiles.Data
{
    [Table(DatabaseSchema.TableProfile)]
    public class ProfileData : BaseData<int>
    {
        [Column(DatabaseSchema.ColumnName)]
        public string Name { get; set; }
    }
}
