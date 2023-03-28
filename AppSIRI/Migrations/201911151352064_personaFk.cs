namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personaFk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas");
            DropIndex("dbo.Personas", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonasModel_Id" });
            AddColumn("dbo.Personas", "User", c => c.Guid(nullable: false));
            DropColumn("dbo.Personas", "User_Id");
            DropColumn("dbo.AspNetUsers", "PersonasModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PersonasModel_Id", c => c.Guid());
            AddColumn("dbo.Personas", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Personas", "User");
            CreateIndex("dbo.AspNetUsers", "PersonasModel_Id");
            CreateIndex("dbo.Personas", "User_Id");
            AddForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas", "Id");
            AddForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
