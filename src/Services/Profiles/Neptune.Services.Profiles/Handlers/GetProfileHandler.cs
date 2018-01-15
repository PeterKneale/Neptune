using System;
using System.Collections.Generic;
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
                Profile = new ProfileDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Badges = GetBadges()
                }
            };
        }

        private static List<ProfileBadgeDto> GetBadges()
        {
            return new List<ProfileBadgeDto>
            {
                new ProfileBadgeDto
                {
                    AwardedAt = DateTime.UtcNow.AddHours(-3),
                    Badge = new BadgeDto
                    {
                        Name = "Favourite Question",
                        Description = "Question favorited by 25 users. This badge can be awarded multiple times",
                        Rank = BadgeRank.Gold,
                        Relation = BadgeRelation.Question
                    }
                },
                new ProfileBadgeDto
                {
                    AwardedAt = DateTime.UtcNow.AddHours(-2),
                    Badge = new BadgeDto
                    {
                        Name = "Nice Answer",
                        Description = "Answer score of 10 or more. This badge can be awarded multiple times.",
                        Rank = BadgeRank.Silver,
                        Relation = BadgeRelation.Question
                    }
                }
            };
        }
    }
}
