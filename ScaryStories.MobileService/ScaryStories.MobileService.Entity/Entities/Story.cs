namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Story
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        [StringLength(300)]
        public string Url { get; set; }

        public Guid SourceId { get; set; }

        public Guid PhotoId { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [MaxLength(50)]
        public byte[] Version { get; set; }

       // public virtual Category Category { get; set; }

        public virtual Photo Photo { get; set; }

       // public virtual Source Source { get; set; }
    }
}
