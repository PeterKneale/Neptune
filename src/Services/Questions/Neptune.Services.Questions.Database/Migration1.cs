using FluentMigrator;
using System;

namespace Neptune.Services.Questions.Database
{
    [Migration(1, "Add tables")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            Create.Table(DatabaseSchema.TableQuestion)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsInt16()
                    .PrimaryKey()
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnTitle)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnBody)
                    .AsString(DatabaseSchema.LengthLong)
                    .NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DatabaseSchema.TableQuestion);
        }

    }
}
