using Neptune.Services.Common;
using Neptune.Services.Common.Bus;
using System;

namespace Neptune.Services.Identities.Messages
{
    public class GetIdentityRequest : IQuery
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class GetIdentityResponse : IQueryResult
    {
        public IdentityDto Identity { get; set; }
    }
}
