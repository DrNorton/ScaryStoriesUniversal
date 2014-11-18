using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryStoriesUniversal.Dtos
{
    public class VideoDto:BaseDto
    {
        public string Url { get; set; }
        public byte[] Thumb { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string ChannalName { get; set; }
        public string SourceId { get; set; }
        public byte[] Image { get; set; }
    }
}
