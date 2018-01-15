using Dapper;
using Neptune.Services.Common.Data;
using Neptune.Services.Identities.Database;
using System;

namespace Neptune.Services.Identities.Data
{
    [Table(DatabaseSchema.TableUser)]
    public class UserData : BaseData<Guid>
    {
        [Column(DatabaseSchema.ColumnEmail)]
        public string Email { get; set; }

        [Column(DatabaseSchema.ColumnUserName)]
        public string UserName { get; set; }

        [Column(DatabaseSchema.ColumnPassword)]
        public string Password { get; set; }
    }
}
