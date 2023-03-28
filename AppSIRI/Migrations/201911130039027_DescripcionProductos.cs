namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescripcionProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "descripcion");
        }
    }
}
