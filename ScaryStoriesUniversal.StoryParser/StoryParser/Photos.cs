//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoryParser
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photos
    {
        public Photos()
        {
            this.Stories = new HashSet<Stories>();
        }
    
        public System.Guid Id { get; set; }
        public byte[] Image { get; set; }
        public byte[] Thumb { get; set; }
        public Nullable<System.DateTimeOffset> CreatedAt { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTimeOffset> UpdatedAt { get; set; }
        public byte[] Version { get; set; }
    
        public virtual ICollection<Stories> Stories { get; set; }
    }
}