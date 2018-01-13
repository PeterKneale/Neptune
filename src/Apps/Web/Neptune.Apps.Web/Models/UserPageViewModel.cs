using System;

namespace Neptune.Apps.Web.Models
{
    public class UserPageViewModel
    {
        public UserViewModel Profile { get; set; }
    }

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
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