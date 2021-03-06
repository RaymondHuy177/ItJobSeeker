namespace ITJobSeeker.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Type = c.String(),
                        Size = c.String(),
                        FirstPictureID = c.Guid(),
                        SecondPictureID = c.Guid(),
                        ThirdPictureID = c.Guid(),
                        AvatarID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        SmallDescription = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Requirement = c.String(nullable: false),
                        Salary = c.String(nullable: false),
                        Benefits = c.String(nullable: false),
                        FirstTechStack = c.String(nullable: false, maxLength: 25),
                        SecondTechStack = c.String(nullable: false, maxLength: 25),
                        ThirdTechStack = c.String(nullable: false, maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        CompanyID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 15),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Telephone = c.String(),
                        IsMale = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RoleID = c.Guid(nullable: false),
                        Picture_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.Picture_ID)
                .Index(t => t.RoleID)
                .Index(t => t.Picture_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TechnologyKeywords",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Picture_ID", "dbo.Pictures");
            DropForeignKey("dbo.Companies", "ID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "Picture_ID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropIndex("dbo.Companies", new[] { "ID" });
            DropTable("dbo.TechnologyKeywords");
            DropTable("dbo.Pictures");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
            DropTable("dbo.Companies");
        }
    }
}
