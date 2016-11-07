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
                        AvatarID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.AvatarID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.AvatarID);
            
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
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleID = c.Guid(nullable: false),
                        AvatarID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.AvatarID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.AvatarID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Requirement = c.String(nullable: false),
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
            DropForeignKey("dbo.Companies", "ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Companies", "AvatarID", "dbo.Pictures");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "AvatarID", "dbo.Pictures");
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropIndex("dbo.Users", new[] { "AvatarID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Companies", new[] { "AvatarID" });
            DropIndex("dbo.Companies", new[] { "ID" });
            DropTable("dbo.TechnologyKeywords");
            DropTable("dbo.Jobs");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Pictures");
            DropTable("dbo.Companies");
        }
    }
}
