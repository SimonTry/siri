namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personas1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas");
            DropIndex("dbo.AspNetUsers", new[] { "PersonasModel_Id" });
            DropColumn("dbo.AspNetUsers", "PersonasModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PersonasModel_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "PersonasModel_Id");
            AddForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas", "Id");
        }
    }
}
