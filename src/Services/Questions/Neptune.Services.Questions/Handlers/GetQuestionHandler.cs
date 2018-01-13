using System.Threading.Tasks;
using AutoMapper;
using Neptune.Services.Common.Bus;
using Neptune.Services.Questions.Data;
using Neptune.Services.Questions.Messages;

namespace Neptune.Services.Questions.Handlers
{
    public class GetQuestionHandler : IQueryHandler<GetQuestionRequest, GetQuestionResponse>
    {
        private readonly IQuestionSource _source;

        public GetQuestionHandler(IQuestionSource source)
        {
            _source = source;
        }

        public async Task<GetQuestionResponse> Execute(GetQuestionRequest query)
        {
            var data = await _source.GetAsync(query.Id);
            if (data == null)
            {
                return new GetQuestionResponse();
            }

            var dto = Mapper.Map<QuestionData, QuestionDto>(data);

            return new GetQuestionResponse
            {
                Question = dto
            };
        }
    }
}
