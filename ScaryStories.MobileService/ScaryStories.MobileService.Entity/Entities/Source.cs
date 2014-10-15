using Newtonsoft.Json;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Source
    {
        public Source()
        {
            Stories = new HashSet<Story>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [MaxLength(50)]
        public byte[] Version { get; set; }
          [JsonIgnore] 
        public virtual ICollection<Story> Stories { get; set; }
    }
}
