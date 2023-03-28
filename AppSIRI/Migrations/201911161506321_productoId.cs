namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Remates", "productoId", c => c.Guid(nullable: false));
            DropColumn("dbo.Remates", "productoFk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Remates", "productoFk", c => c.Guid(nullable: false));
            DropColumn("dbo.Remates", "productoId");
        }
    }
}
