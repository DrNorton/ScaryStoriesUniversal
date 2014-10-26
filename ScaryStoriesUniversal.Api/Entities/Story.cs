using System;
using Microsoft.WindowsAzure.MobileServices;

namespace ScaryStoriesUniversal.Api.Entities
{
    public class Story:BaseEntity
    {
        public Guid CategoryId { get; set; }

        public Guid SourceId { get; set; }

        public Guid PhotoId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }


        public string Url { get; set; }

        [Version]
        public string Version { get; set; }

     
    }
}
