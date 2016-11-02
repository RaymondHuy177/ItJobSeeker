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

        private void InsertInitialData(ItJobSeekerEntities context)
        {
            context.Pictures.Add(
                new Model.Models.Picture { ID= new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"), Name="MyPicture" }
                );
            context.Roles.Add(
                new Model.Models.Role { ID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"), Name = "admin" }
                );
            context.SaveChanges();
            context.Users.AddOrUpdate(
                new Model.Models.User { ID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"), Email = "example@yahoo.com",
                    FirstName = "Nguyen", LastName = "Khang", Password="password",
                    AvatarID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"),
                    RoleID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b")
                }
                );
        }

        protected override void Seed(ITJobSeeker.Repository.ItJobSeekerEntities context)
        {
            InsertInitialData(context);
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
            ////
            //context.Roles.Add(new Model.Models.Role { Name = "Admin" });
            //context.Roles.Add(new Model.Models.Role { Name = "JobSeeker" });
            //context.Roles.Add(new Model.Models.Role { Name = "Recruiter" });
        }
    }
}
