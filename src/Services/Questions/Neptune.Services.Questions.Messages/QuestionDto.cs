using System;
using System.Collections.Generic;

namespace Neptune.Services.Questions.Messages
{
    public class QuestionDto : ICreated, IUpdated
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        // Created
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        // Updated
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedById { get; set; }

        // Other
        public DateTime LastActivity { get; set; }

        // Calculated
        public int Views { get; set; }
        public int TotalVotes { get; set; }
        public int TotalStars { get; set; }
        public int TotalAnswers { get; set; }
    }

}
