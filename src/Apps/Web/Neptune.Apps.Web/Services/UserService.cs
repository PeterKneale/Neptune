using Neptune.Apps.Web.Models;
using Neptune.Services.Common.Bus;
using Neptune.Services.Identities.Messages;
using Neptune.Services.Profiles.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Neptune.Apps.Web.Services
{
    public interface IUserService
    {
        Task<UserViewModel> Get(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IQueryDispatcher _queries;

        public UserService(IQueryDispatcher queries)
        {
            _queries = queries;
        }

        public async Task<UserViewModel> Get(Guid id)
        {
            var identityResponse = _queries.Request<GetIdentityRequest, GetIdentityResponse>(new GetIdentityRequest { Id = id });
            var profileResponse = _queries.Request<GetProfileRequest, GetProfileResponse>(new GetProfileRequest { Id = id });
            await Task.WhenAll(identityResponse, profileResponse);

            var identity = identityResponse.Result.Identity;
            var profile = profileResponse.Result.Profile;

            return new UserViewModel
            {
                Id = id,
                Name = identity.FirstName + " " + identity.LastName,
                UserName = identity.UserName,
                TotalBronzeBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Bronze),
                TotalSilverBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Silver),
                TotalGoldBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Gold)
            };
        }
    }
}
