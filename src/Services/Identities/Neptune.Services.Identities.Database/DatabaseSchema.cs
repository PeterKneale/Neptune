namespace Neptune.Services.Identities.Database
{
    public static class DatabaseSchema
    {
        public const string TableUser = "User";

        public const string ColumnId = "Id";
        public const string ColumnEmail = "Email";
        public const string ColumnUserName = "UserName";
        public const string ColumnPassword = "Password";

        public const int LengthDefault = 100;
        public const int LengthLong = 4000;
    }
}
