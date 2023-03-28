namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pujas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pujas",
                c => new
                    {
                        PujaId = c.Guid(nullable: false, identity: true),
                        RemateId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        valorPuja = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PujaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pujas");
        }
    }
}
