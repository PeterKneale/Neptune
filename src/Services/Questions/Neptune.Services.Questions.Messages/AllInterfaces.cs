using System;

namespace Neptune.Services.Questions.Messages
{
    public interface ICreated
    {
        DateTime CreatedAt { get; set; }
        Guid CreatedById { get; set; }
    }

    public interface IUpdated
    {
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedById { get; set; }
    }
}
