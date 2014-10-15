using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScaryStories.MobileService.Entity;

namespace ScaryStories.MobileService.Dtos
{
    public class StoryDto : EntityDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

     
        public string Url { get; set; }

  

        public PhotoDto Photo { get; set; }

    }
}
