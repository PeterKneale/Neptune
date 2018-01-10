namespace Neptune.Services.Questions.Database
{
    public static class DatabaseSchema
    {
        public const string TableQuestion = "Question";
        public const string TableAnswer = "Answer";

        public const string ColumnId = "Id";
        public const string ColumnTitle = "Title";
        public const string ColumnBody = "Body";

        public const int LengthDefault = 100;
        public const int LengthLong = 4000;
    }
}
