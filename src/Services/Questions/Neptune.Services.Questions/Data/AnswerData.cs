using Dapper;
using Neptune.Services.Common.Data;
using Neptune.Services.Questions.Database;
using System;

namespace Neptune.Services.Questions.Data
{
    [Table(DatabaseSchema.TableAnswer)]
    public class AnswerData : BaseData<Guid>
    {
        [Column(DatabaseSchema.ColumnQuestionId)]
        public Guid QuestionId { get; set; }

        [Column(DatabaseSchema.ColumnBody)]
        public string Body { get; set; }

        // Created
        [Column(DatabaseSchema.ColumnCreatedAt)]
        public DateTime CreatedAt { get; set; }

        [Column(DatabaseSchema.ColumnCreatedById)]
        public Guid CreatedById { get; set; }

        [Column(DatabaseSchema.ColumnCreatedByName)]
        public string CreatedByName { get; set; }

        // Updated
        [Column(DatabaseSchema.ColumnUpdatedAt)]
        public DateTime? UpdatedAt { get; set; }

        [Column(DatabaseSchema.ColumnUpdatedById)]
        public Guid? UpdatedById { get; set; }

        [Column(DatabaseSchema.ColumnUpdatedByName)]
        public string UpdatedByName { get; set; }

        // Accepted
        [Column(DatabaseSchema.ColumnAcceptedAt)]
        public DateTime? AcceptedAt { get; set; }

        [Column(DatabaseSchema.ColumnAcceptedById)]
        public Guid? AcceptedById { get; set; }

        [Column(DatabaseSchema.ColumnAcceptedByName)]
        public string AcceptedByName { get; set; }
        
        [Column(DatabaseSchema.ColumnLastActivity)]
        public DateTime LastActivity { get; set; }
    }
}
