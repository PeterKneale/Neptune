namespace Neptune.Apps.Web.Services
{
    public static class API
    {
        private static string baseUri = "http://localhost:50339/api/v1";

        public static class User
        {
            private static string baseUri = API.baseUri + "/user/";

            public static string Get(int id)
            {
                return $"{baseUri}{id}";
            }
        }
    }
}
