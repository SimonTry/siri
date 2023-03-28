namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProductos : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Productos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        nombreProducto = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
