namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productos : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Productos");
            AlterColumn("dbo.Productos", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Productos", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Productos");
            AlterColumn("dbo.Productos", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Productos", "Id");
        }
    }
}
