namespace AppSIRI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "PersonasModel_Id", c => c.Guid());
            CreateIndex("dbo.Personas", "User_Id");
            CreateIndex("dbo.AspNetUsers", "PersonasModel_Id");
            AddForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas", "Id");
            DropColumn("dbo.Personas", "userIdFk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personas", "userIdFk", c => c.Guid(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "PersonasModel_Id", "dbo.Personas");
            DropForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "PersonasModel_Id" });
            DropIndex("dbo.Personas", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "PersonasModel_Id");
            DropColumn("dbo.Personas", "User_Id");
        }
    }
}
