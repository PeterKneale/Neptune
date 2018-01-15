using System;
using System.Threading.Tasks;
using Neptune.Services.Common.Bus;
using Neptune.Services.Identities.Data;
using Neptune.Services.Identities.Messages;

namespace Neptune.Services.Identities.Handlers
{
    public class GetIdentityHandler : IQueryHandler<GetIdentityRequest, GetIdentityResponse>
    {
        private readonly IUserSource _source;

        public GetIdentityHandler(IUserSource source)
        {
            _source = source;
        }

        public async Task<GetIdentityResponse> Execute(GetIdentityRequest query)
        {
            UserData data = null;
            if(query.Id != Guid.Empty)
            {
                data = await _source.GetAsync(query.Id);
            }
            if (!string.IsNullOrEmpty(query.Email))
            {
                data = await _source.GetByEmail(query.Email);
            }
            if (!string.IsNullOrEmpty(query.UserName))
            {
                data = await _source.GetByUserName(query.UserName);
            }

            if (data == null)
            {
                return new GetIdentityResponse();
            }
            return new GetIdentityResponse
            {
                Identity = new IdentityDto { Id = data.Id, UserName = data.UserName, Email = data.Email }
            };
        }
    }
}
