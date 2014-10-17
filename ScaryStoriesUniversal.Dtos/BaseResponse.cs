using System;

namespace ScaryStoriesUniversal.Dtos
{
    public class BaseResponse
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public bool? Deleted { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}
