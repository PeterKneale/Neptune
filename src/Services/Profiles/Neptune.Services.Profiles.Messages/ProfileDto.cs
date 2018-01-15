using System;
using System.Collections.Generic;

namespace Neptune.Services.Profiles.Messages
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProfileBadgeDto> Badges { get; set; }
    }

    public class ProfileBadgeDto
    {
        public DateTime AwardedAt { get; set; }
        public BadgeDto Badge { get; set; }
    }

    public class BadgeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BadgeRank Rank { get; set; }
        public BadgeRelation Relation { get; set; }
        public Guid RelationId { get; set; }
    }

    public enum BadgeRank
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3,
    }

    public enum BadgeRelation
    {
        None = 1,
        General = 2,
        Question = 3,
        Answer = 4
    }

}
