namespace ITJobSeeker.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model.Models;

    public partial class ItJobSeekerEntities : DbContext
    {
        public ItJobSeekerEntities()
            : base("name=ItJobSeekerEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<TechnologyKeyword> TechnologyKeywords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasRequired(j => j.Comapny).WithMany(c => c.Jobs);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
