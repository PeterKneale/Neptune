namespace Neptune.Apps.Web.Models
{
    public class UserPageViewModel
    {
        public ProfileViewModel Profile { get; set; }
    }

    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}