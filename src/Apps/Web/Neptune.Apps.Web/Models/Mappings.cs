using AutoMapper;
using Neptune.Services.Profiles.Messages;
using Neptune.Services.Questions.Messages;

namespace Neptune.Apps.Web.Models
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<QuestionDto, QuestionViewModel>();
        }
    }
}