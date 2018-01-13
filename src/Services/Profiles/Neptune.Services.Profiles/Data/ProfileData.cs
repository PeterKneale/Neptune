using Dapper;
using Neptune.Services.Common.Data;
using Neptune.Services.Profiles.Database;
using System;

namespace Neptune.Services.Profiles.Data
{
    [Table(DatabaseSchema.TableProfile)]
    public class ProfileData : BaseData<Guid>
    {
        [Column(DatabaseSchema.ColumnName)]
        public string Name { get; set; }
    }
}
