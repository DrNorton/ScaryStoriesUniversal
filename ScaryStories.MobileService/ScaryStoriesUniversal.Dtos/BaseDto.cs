using System;

namespace ScaryStoriesUniversal.Dtos
{
    public class BaseDto
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public bool? Deleted { get; set; }
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}
