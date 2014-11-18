using System;

namespace ScaryStoriesUniversal.Api.Entities
{
    public interface IBaseEntity
    {
        DateTimeOffset? CreatedAt { get; set; }
        string Id { get; set; }
    }
}