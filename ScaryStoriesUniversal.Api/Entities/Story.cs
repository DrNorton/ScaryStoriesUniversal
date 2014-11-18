using System;
using Microsoft.WindowsAzure.MobileServices;

namespace ScaryStoriesUniversal.Api.Entities
{
    public class Story:BaseEntity
    {
        public string CategoryId { get; set; }

        public string SourceId { get; set; }

        public string PhotoId { get; set; }

        public string Name { get; set; }
        public long Likes { get; set; }
        public string Text { get; set; }
        public byte[] Thumb { get; set; }

        public string Url { get; set; }


     
    }
}
