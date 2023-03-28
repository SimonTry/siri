namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        productoId = c.Guid(nullable: false, identity: true),
                        nombreProducto = c.String(nullable: false),
                        descripcionProducto = c.String(),
                    })
                .PrimaryKey(t => t.productoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
