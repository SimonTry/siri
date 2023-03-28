namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pujas3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pujas", "RemateIdFk", c => c.Guid(nullable: false));
            AddColumn("dbo.Pujas", "UserIdFk", c => c.Guid(nullable: false));
            DropColumn("dbo.Pujas", "RemateId");
            DropColumn("dbo.Pujas", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pujas", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Pujas", "RemateId", c => c.Guid(nullable: false));
            DropColumn("dbo.Pujas", "UserIdFk");
            DropColumn("dbo.Pujas", "RemateIdFk");
        }
    }
}
