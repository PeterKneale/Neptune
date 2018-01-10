namespace Neptune.Services.Profiles.Database
{
    public static class DatabaseSchema
    {
        public const string TableProfile = "Profile";

        public const string ColumnId = "Id";
        public const string ColumnName = "Name";

        public const int LengthDefault = 100;
        public const int LengthLong = 4000;
    }
}
