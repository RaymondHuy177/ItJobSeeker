namespace ITJobSeeker.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITJobSeeker.Repository.ItJobSeekerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITJobSeeker.Repository.ItJobSeekerEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Roles.Add(new Model.Models.Role { Name = "Admin" });
            context.Roles.Add(new Model.Models.Role { Name = "JobSeeker" });
            context.Roles.Add(new Model.Models.Role { Name = "Recruiter" });
        }
    }
}
