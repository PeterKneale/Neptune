using FluentMigrator;
using System;

namespace Neptune.Services.Profiles.Database
{
    [Migration(1, "Add tables")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            Create.Table(DatabaseSchema.TableProfile)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsInt16()
                    .PrimaryKey()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DatabaseSchema.TableProfile);
        }

    }
}
