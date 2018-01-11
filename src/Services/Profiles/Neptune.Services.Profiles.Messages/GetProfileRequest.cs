using Neptune.Services.Common;
using Neptune.Services.Common.Bus;
using System;

namespace Neptune.Services.Profiles.Messages
{
    public class GetProfileRequest : IQuery
    {
        public int Id { get; set; }
    }

    public class GetProfileResponse : IQueryResult
    {
        public ProfileDto Profile { get; set; }
    }
}
