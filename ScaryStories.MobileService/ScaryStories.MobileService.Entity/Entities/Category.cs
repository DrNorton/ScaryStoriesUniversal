using Newtonsoft.Json;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Category()
        {
            Stories = new HashSet<Story>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        [Column(TypeName = "image")]
        public byte[] Thumb { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [MaxLength(50)]
        public byte[] Version { get; set; }

          [JsonIgnore] 
        public virtual ICollection<Story> Stories { get; set; }
    }
}
