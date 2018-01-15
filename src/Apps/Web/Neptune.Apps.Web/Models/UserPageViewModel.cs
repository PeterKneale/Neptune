using System;

namespace Neptune.Apps.Web.Models
{
    public class UserPageViewModel
    {
        public UserViewModel User { get; set; }
    }

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int TotalGoldBadges { get; set; }
        public int TotalSilverBadges { get; set; }
        public int TotalBronzeBadges { get; set; }
    }

    public class QuestionPageViewModel
    {
        public QuestionViewModel Question { get; set; }
        public UserViewModel UserAsking { get; set; }
    }

    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}