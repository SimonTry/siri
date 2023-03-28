namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionUserPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "userIdFk", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "userIdFk");
        }
    }
}
