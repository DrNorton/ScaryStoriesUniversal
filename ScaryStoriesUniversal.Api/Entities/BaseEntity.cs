using System;
using System.Threading.Tasks;

namespace ScaryStoriesUniversal.Api.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public bool? Deleted { get; set; }
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }

      
    }
}
