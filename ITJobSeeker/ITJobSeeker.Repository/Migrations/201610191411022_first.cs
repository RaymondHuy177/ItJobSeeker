namespace ITJobSeeker.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "AvatarID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Companies", "AvatarID");
            AddForeignKey("dbo.Companies", "AvatarID", "dbo.Pictures", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "AvatarID", "dbo.Pictures");
            DropIndex("dbo.Companies", new[] { "AvatarID" });
            DropColumn("dbo.Companies", "AvatarID");
        }
    }
}
