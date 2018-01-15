using System;

namespace Neptune.Services.Questions.Messages
{
    public class AnswerDto : ICreated, IUpdated
    {
        public string Body { get; set; }
        
        public Guid CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        public Guid? AcceptedById { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
    }

}
