using AutoMapper;
using Neptune.Services.Questions.Data;
using Neptune.Services.Questions.Messages;

namespace Neptune.Services.Questions.Handlers
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<QuestionData, QuestionDto>();
        }
    }
}
