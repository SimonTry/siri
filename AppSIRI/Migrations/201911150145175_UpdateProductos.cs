namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productos", "usuarioFk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "usuarioFk", c => c.Guid(nullable: false));
        }
    }
}
