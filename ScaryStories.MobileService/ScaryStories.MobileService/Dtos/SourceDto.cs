using Newtonsoft.Json;
using ScaryStories.MobileService.Dtos;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SourceDto : EntityDto
    {
        public SourceDto()
        {
        }

      
        public string Name { get; set; }

      
        public byte[] Image { get; set; }

        public string Url { get; set; }

    }
}
