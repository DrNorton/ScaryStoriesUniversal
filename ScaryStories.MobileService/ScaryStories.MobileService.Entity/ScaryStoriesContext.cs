using System.Data.Entity.ModelConfiguration.Conventions;

namespace ScaryStories.MobileService.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScaryStoriesContext : DbContext
    {
        public ScaryStoriesContext()
            : base("name=ScaryStoriesConnectionString")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Stories)
            //    .WithRequired(e => e.Category)
            //    .WillCascadeOnDelete(false);
       

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Stories)
                .WithRequired(e => e.Photo)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Source>()
            //    .HasMany(e => e.Stories)
            //    .WithRequired(e => e.Source)
            //    .WillCascadeOnDelete(false);
        }
    }
}
