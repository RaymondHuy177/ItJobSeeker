﻿namespace ITJobSeeker.Repository.Migrations
{
    using Model.Models;
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
        private void InsertInitialData(ItJobSeekerEntities context)
        {
            InsertInitialRole(context);
            InsertInitialPicture(context);
            InsertInitialUser(context);
            InsertInitialCompany(context);
            InsertInitialJob(context);
        }
        private void InsertInitialUser(ItJobSeekerEntities context)
        {
            context.Users.AddOrUpdate(
                new Model.Models.User
                {
                    ID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"),
                    Email = "example@yahoo.com",
                    FirstName = "Nguyen",
                    LastName = "Khang",
                    Password = "password",
                    AvatarID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"),
                    RoleID = new Guid("4c06668e-2625-4275-8e87-07f071d0f358")
                },
                new Model.Models.User
                {
                    ID = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837"),
                    Email = "example@yahoo.com",
                    FirstName = "Quan",
                    LastName = "Mai",
                    Password = "password2",
                    AvatarID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"),
                    RoleID = new Guid("31e2b54f-4168-42f0-9165-808d3d71d80f")
                }
                );
        }
        private void InsertInitialPicture(ItJobSeekerEntities context)
        {
            context.Pictures.Add(
                new Model.Models.Picture { ID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"), Name = "MyPicture" }
                );
        }
        private void InsertInitialRole(ItJobSeekerEntities context)
        {

            context.Roles.Add(
                new Model.Models.Role { ID = new Guid("4c06668e-2625-4275-8e87-07f071d0f358"), Name = "admin" }
                );
            context.Roles.Add(
                new Model.Models.Role { ID = new Guid("31e2b54f-4168-42f0-9165-808d3d71d80f"), Name = "recruiter" }
                );

        }
        private void InsertInitialJob(ItJobSeekerEntities context)
        {
            context.Jobs.AddOrUpdate(
                new Job
                {
                    ID = new Guid("73f65af7-5b6d-4e15-a732-466286bca84c"),
                    Benefits = "Benefit",
                    CompanyID = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837"),
                    Description = "Description",
                    IsActive = true,
                    FirstTechStack = "MVC",
                    SecondTechStack = "ASP.NET",
                    ThirdTechStack = "Java",
                    Requirement = "Requirement",
                    Location = "HoChiMinh",
                    Name = "7 Software Engineer"
                },
                new Job
                {
                    ID = new Guid("91b79a8b-a47a-4b3d-a67b-6e46349b01af"),
                    Benefits = "Benefit2",
                    CompanyID = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837"),
                    Description = "Description2",
                    IsActive = true,
                    FirstTechStack = "J2EE",
                    SecondTechStack = "UI-UX",
                    ThirdTechStack = "Java",
                    Requirement = "Requirement2",
                    Location = "HoChiMinh",
                    Name = "7 Java Software Engineer"
                }
                );
        }
        private void InsertInitialCompany(ItJobSeekerEntities context)
        {
            context.Companies.AddOrUpdate(
                new Company
                {
                    ID = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837"),
                    Name = "KMS",
                    Address = "123 Phạm phú thứ",
                    Location = "HoCHiMinh",
                    AvatarID = new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b")
                }
                );
        }

    }
}
