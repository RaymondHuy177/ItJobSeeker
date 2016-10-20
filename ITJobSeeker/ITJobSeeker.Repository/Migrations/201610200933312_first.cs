namespace ITJobSeeker.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Location", c => c.String());
            AlterColumn("dbo.Companies", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "Address", c => c.String());
            DropColumn("dbo.Jobs", "Location");
        }
    }
}
