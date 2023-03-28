namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        secondName = c.String(),
                        firstLastName = c.String(nullable: false),
                        secondLastName = c.String(nullable: false),
                        identification = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        nombreProducto = c.String(nullable: false),
                        usuarioFk = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
            DropTable("dbo.Personas");
        }
    }
}
