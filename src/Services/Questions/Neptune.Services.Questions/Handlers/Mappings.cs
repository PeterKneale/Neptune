using AutoMapper;
using Neptune.Services.Questions.Data;
using Neptune.Services.Questions.Messages;

namespace Neptune.Services.Questions.Handlers
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<QuestionData, QuestionDto>()
                .ForMember(opt=>opt.TotalStars, x=>x.Ignore())
                .ForMember(opt => opt.TotalVotes, x => x.Ignore())
                .ForMember(opt => opt.TotalAnswers, x => x.Ignore());
            CreateMap<AnswerData, AnswerDto>();
        }
    }
}
