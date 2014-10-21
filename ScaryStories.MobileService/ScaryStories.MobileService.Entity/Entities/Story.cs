using Microsoft.WindowsAzure.Mobile.Service;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Story : EntityData
    {
      
        public string CategoryId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        [StringLength(300)]
        public string Url { get; set; }

        public string SourceId { get; set; }

        public string PhotoId { get; set; }

       // public virtual Category Category { get; set; }

         [ForeignKey("Id")]
        public virtual Photo Photo { get; set; }

       // public virtual Source Source { get; set; }
    }
}
