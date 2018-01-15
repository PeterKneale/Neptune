using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Neptune.Services.Common.Bus;
using Neptune.Services.Questions.Data;
using Neptune.Services.Questions.Messages;

namespace Neptune.Services.Questions.Handlers
{
    public class GetQuestionHandler : IQueryHandler<GetQuestionRequest, GetQuestionResponse>
    {
        private readonly IQuestionSource _questions;
        private readonly IAnswerSource _answers;

        public GetQuestionHandler(IQuestionSource source, IAnswerSource answers)
        {
            _questions = source;
            _answers = answers;
        }

        public async Task<GetQuestionResponse> Execute(GetQuestionRequest query)
        {
            var questionResponse = _questions.GetAsync(query.Id);
            var answersResponse = _answers.ListByQuestion(query.Id);
            var totalAnswers = _questions.CountAnswers(query.Id);
            var totalVotes = _questions.CountVotes(query.Id);
            var totalStars = _questions.CountStars(query.Id);

            await Task.WhenAll(questionResponse, answersResponse, totalAnswers, totalVotes, totalStars);

            var question = questionResponse.Result;
            var answers = answersResponse.Result;

            var questionDto = Mapper.Map<QuestionData, QuestionDto>(question);
            questionDto.TotalAnswers = totalAnswers.Result;
            questionDto.TotalVotes = totalVotes.Result;
            questionDto.TotalStars = totalStars.Result;

            var answersDto = Mapper.Map<IEnumerable<AnswerData>, IEnumerable<AnswerDto>>(answers);

            return new GetQuestionResponse
            {
                Question = questionDto
            };
        }
    }
}
