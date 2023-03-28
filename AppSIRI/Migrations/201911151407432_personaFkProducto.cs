namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personaFkProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "persona", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "persona");
        }
    }
}
