using FluentMigrator;
using System;

namespace Neptune.Services.Identities.Database
{
    [Migration(1, "Add tables")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            Create.Table(DatabaseSchema.TableUser)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnEmail)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnUserName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnPassword)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DatabaseSchema.TableUser);
        }

    }
}
