using FluentMigrator;

namespace Neptune.Services.Questions.Database
{
    [Migration(1, "Add tables")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            CreateQuestionTable();
            CreateQuestionVotesTable();
            CreateQuestionStarsTable();
            CreateAnswerTable();
            CreateAnswerVotesTable();
            CreateRelationships();
        }

        private void CreateRelationships()
        {
            // QuestionVotes.QuestionId -> Question.Id
            Create.ForeignKey()
                .FromTable(DatabaseSchema.TableQuestionVotes)
                .ForeignColumn(DatabaseSchema.ColumnQuestionId)
                .ToTable(DatabaseSchema.TableQuestion)
                .PrimaryColumn(DatabaseSchema.ColumnId);
            
            // QuestionStars.QuestionId -> Question.Id
            Create.ForeignKey()
                .FromTable(DatabaseSchema.TableQuestionStars)
                .ForeignColumn(DatabaseSchema.ColumnQuestionId)
                .ToTable(DatabaseSchema.TableQuestion)
                .PrimaryColumn(DatabaseSchema.ColumnId);

            // Answer.QuestionId -> Question.Id
            Create.ForeignKey()
                .FromTable(DatabaseSchema.TableAnswer)
                .ForeignColumn(DatabaseSchema.ColumnQuestionId)
                .ToTable(DatabaseSchema.TableQuestion)
                .PrimaryColumn(DatabaseSchema.ColumnId);

            // AnswerVotes.AnswerId -> AAnswer.Id
            Create.ForeignKey()
                .FromTable(DatabaseSchema.TableAnswerVotes)
                .ForeignColumn(DatabaseSchema.ColumnAnswerId)
                .ToTable(DatabaseSchema.TableAnswer)
                .PrimaryColumn(DatabaseSchema.ColumnId);
        }

        private void CreateAnswerTable()
        {
            Create.Table(DatabaseSchema.TableAnswer)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnQuestionId)
                    .AsGuid()
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnBody)
                    .AsString(DatabaseSchema.LengthLong)
                    .NotNullable()

                // Accepted
                .WithColumn(DatabaseSchema.ColumnAcceptedAt)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnAcceptedById)
                    .AsGuid()
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnAcceptedByName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .Nullable()

                // Created
                .WithColumn(DatabaseSchema.ColumnCreatedAt)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnCreatedById)
                    .AsGuid()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnCreatedByName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()

                // Updated
                .WithColumn(DatabaseSchema.ColumnUpdatedAt)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnUpdatedById)
                    .AsGuid()
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnUpdatedByName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .Nullable()

                // Other
                .WithColumn(DatabaseSchema.ColumnViews)
                    .AsInt32()
                    .WithDefaultValue(0)
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnLastActivity)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .NotNullable();
        }

        private void CreateQuestionStarsTable()
        {
            Create.Table(DatabaseSchema.TableQuestionStars)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnQuestionId)
                    .AsGuid()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnUserId)
                    .AsGuid()
                    .NotNullable();
        }

        private void CreateQuestionVotesTable()
        {
            Create.Table(DatabaseSchema.TableQuestionVotes)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnQuestionId)
                    .AsGuid()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnUserId)
                    .AsGuid()
                    .NotNullable();
        }

        private void CreateAnswerVotesTable()
        {
            Create.Table(DatabaseSchema.TableAnswerVotes)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnAnswerId)
                    .AsGuid()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnUserId)
                    .AsGuid()
                    .NotNullable();
        }

        private void CreateQuestionTable()
        {
            Create.Table(DatabaseSchema.TableQuestion)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnTitle)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnBody)
                    .AsString(DatabaseSchema.LengthLong)
                    .NotNullable()

                // Created
                .WithColumn(DatabaseSchema.ColumnCreatedAt)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnCreatedById)
                    .AsGuid()
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnCreatedByName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .NotNullable()

                // Updated
                .WithColumn(DatabaseSchema.ColumnUpdatedAt)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnUpdatedById)
                    .AsGuid()
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnUpdatedByName)
                    .AsString(DatabaseSchema.LengthDefault)
                    .Nullable()

                // Other
                .WithColumn(DatabaseSchema.ColumnViews)
                    .AsInt32()
                    .WithDefaultValue(0)
                    .NotNullable()

                .WithColumn(DatabaseSchema.ColumnLastActivity)
                    .AsDateTime()
                    .WithDefault(SystemMethods.CurrentUTCDateTime)
                    .NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DatabaseSchema.TableAnswerVotes);
            Delete.Table(DatabaseSchema.TableAnswer);
            Delete.Table(DatabaseSchema.TableQuestionStars);
            Delete.Table(DatabaseSchema.TableQuestionVotes);
            Delete.Table(DatabaseSchema.TableQuestion);
        }
    }
}
