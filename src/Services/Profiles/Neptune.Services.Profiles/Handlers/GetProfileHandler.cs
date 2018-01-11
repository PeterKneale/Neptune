using System.Threading.Tasks;
using Neptune.Services.Common.Bus;
using Neptune.Services.Profiles.Data;
using Neptune.Services.Profiles.Messages;

namespace Neptune.Services.Profiles.Handlers
{
    public class GetProfileHandler : IQueryHandler<GetProfileRequest, GetProfileResponse>
    {
        private readonly IProfileSource _source;

        public GetProfileHandler(IProfileSource source)
        {
            _source = source;
        }

        public async Task<GetProfileResponse> Execute(GetProfileRequest query)
        {
            var data = await _source.GetAsync(query.Id);
            if (data == null)
            {
                return new GetProfileResponse();
            }
            return new GetProfileResponse
            {
                Profile = new ProfileDto { Id = data.Id, Name = data.Name }
            };
        }
    }
}
