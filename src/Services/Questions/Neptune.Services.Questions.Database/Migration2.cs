using FluentMigrator;

namespace Neptune.Services.Questions.Database
{
    [Migration(2, "Add data")]
    public class Migration2 : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Migration2.sql");
        }

        public override void Down()
        {

        }

    }
}
