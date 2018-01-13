using System;

namespace Neptune.Services.Questions.Messages
{
    public class QuestionDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Body { get; set; }

        // Created
        public DateTime CreatedAt { get; set; }
        
        public Guid CreatedById { get; set; }
        
        public string CreatedByName { get; set; }

        // Updated
        public DateTime? UpdatedAt { get; set; }
        
        public Guid? UpdatedById { get; set; }
        
        public string UpdatedByName { get; set; }

        // Other
        public int Views { get; set; }
        public DateTime LastActivity { get; set; }
    }
}
