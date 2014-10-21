using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Photo:EntityData
    {
        public Photo()
        {
            Stories = new HashSet<Story>();
        }


        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Column(TypeName = "image")]
        public byte[] Thumb { get; set; }

          [JsonIgnore]
          [ForeignKey("Id")]
        public virtual ICollection<Story> Stories { get; set; }
    }
}
