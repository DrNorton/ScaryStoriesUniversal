using System;

namespace ScaryStories.MobileService.Dtos
{
    public class EntityDto
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public bool? Deleted { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}
