namespace Neptune.Services.Questions.Database
{
    public static class DatabaseSchema
    {
        public const string TableQuestion = "Question";
        public const string TableQuestionVotes = "QuestionVotes";
        public const string TableQuestionStars = "QuestionStars";

        public const string TableAnswer = "Answer";
        public const string TableAnswerVotes = "AnswerVotes";

        public const string ColumnId = "Id";
        public const string ColumnUserId = "UserId";
        public const string ColumnQuestionId = "QuestionId";
        public const string ColumnAnswerId = "AnswerId";

        public const string ColumnTitle = "Title";
        public const string ColumnBody = "Body";
        public const string ColumnViews = "Views";
        public const string ColumnVotes = "Votes";

        public const string ColumnAccepted = "Accepted";
        public const string ColumnAcceptedAt = "AcceptedAt";
        public const string ColumnAcceptedById = "AcceptedById";
        public const string ColumnAcceptedByName = "AcceptedByName";

        public const string ColumnCreatedAt = "CreatedAt";
        public const string ColumnCreatedById = "CreatedById";
        public const string ColumnCreatedByName = "CreatedByName";

        public const string ColumnUpdatedAt = "UpdatedAt";
        public const string ColumnUpdatedById = "UpdatedById";
        public const string ColumnUpdatedByName = "UpdatedByName";
        
        public const string ColumnLastActivity = "LastActivity";

        public const int LengthDefault = 100;
        public const int LengthLong = 4000;
    }
}
