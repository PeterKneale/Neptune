using Neptune.Services.Common.Bus;
using System;

namespace Neptune.Services.Questions.Messages
{
    public abstract class QuestionBasedEvent : IEvent
    {
        public Guid QuestionId { get; set; }
    }
    public abstract class AnswerBasedEvent : IEvent
    {
        public Guid QuestionId { get; set; }
    }

    public abstract class QuestionVoted : IEvent
    {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
    }

    public abstract class AnswerVoted : IEvent
    {
        public Guid AnswerId { get; set; }
        public Guid UserId { get; set; }
    }

    public class QuestionCreated : QuestionBasedEvent { }
    public class QuestionUpdated : QuestionBasedEvent { }
    public class QuestionStarred : QuestionBasedEvent { }

    public class AnswerCreated : AnswerBasedEvent { }
    public class AnswerUpdated : AnswerBasedEvent { }
    public class AnswerAccepted : AnswerBasedEvent { }

    public class QuestionVotedUp : QuestionVoted { }
    public class QuestionVotedDown : QuestionVoted { }
    public class AnswerVotedUp : AnswerVoted { }
    public class AnswerVotedDown : AnswerVoted { }

}
