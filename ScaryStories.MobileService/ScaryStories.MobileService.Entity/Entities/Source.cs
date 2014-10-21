using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Source : EntityData
    {
        public Source()
        {
            Stories = new HashSet<Story>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

          [JsonIgnore]
          [ForeignKey("Id")]
        public virtual ICollection<Story> Stories { get; set; }
    }
}
