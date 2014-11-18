using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStoriesUniversal.Api.Entities
{
    public class Video:BaseEntity
    {
        public string Url { get; set; }
        public byte[] Thumb { get; set; }
        
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string ChannalName { get; set; }
        public string SourceId { get; set; }
    }
}
