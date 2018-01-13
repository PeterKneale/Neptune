using Neptune.Services.Common;
using Neptune.Services.Common.Bus;
using System;

namespace Neptune.Services.Questions.Messages
{
    public class GetQuestionRequest : IQuery
    {
        public Guid Id { get; set; }
    }

    public class GetQuestionResponse : IQueryResult
    {
        public QuestionDto Question { get; set; }
    }
}
