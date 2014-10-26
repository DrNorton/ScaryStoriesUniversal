using System;
using Microsoft.WindowsAzure.MobileServices;

namespace ScaryStoriesUniversal.Dtos
{
    public class StoryDto:BaseDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }


        public string Url { get; set; }

        [Version]
        public string Version { get; set; }

        public PhotoDto Photo { get; set; }
    }
}
