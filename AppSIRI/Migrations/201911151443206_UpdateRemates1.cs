namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRemates1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Remates", "descripcionRemate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Remates", "descripcionRemate");
        }
    }
}
