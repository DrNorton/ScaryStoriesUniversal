using Newtonsoft.Json;
using ScaryStories.MobileService.Dtos;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class PhotoDto : EntityDto
    {
        public PhotoDto()
        {
        }

        public byte[] Image { get; set; }

        public byte[] Thumb { get; set; }

    }
}
