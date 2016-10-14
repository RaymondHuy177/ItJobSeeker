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
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
