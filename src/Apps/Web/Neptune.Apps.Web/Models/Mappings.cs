using AutoMapper;
using Neptune.Services.Profiles.Messages;

namespace Neptune.Apps.Web.Models
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ProfileDto, ProfileViewModel>();
        }
    }
}