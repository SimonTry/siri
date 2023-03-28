namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Remates",
                c => new
                    {
                        RemateId = c.Guid(nullable: false, identity: true),
                        productoFk = c.Guid(nullable: false),
                        fechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        precioBase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RemateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Remates");
        }
    }
}
