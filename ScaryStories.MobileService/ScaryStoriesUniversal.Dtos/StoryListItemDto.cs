using System;
using Microsoft.WindowsAzure.MobileServices;

namespace ScaryStoriesUniversal.Dtos
{
    public class StoryListItemDto:BaseDto
    {
        public string SourceId { get; set; }
        public string Name { get; set; }

        public byte[] Thumb { get; set; }
    }
}
