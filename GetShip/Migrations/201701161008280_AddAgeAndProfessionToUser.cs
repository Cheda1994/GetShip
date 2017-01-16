namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeAndProfessionToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profesions",
                c => new
                    {
                        ProfesionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProfesionID);
            
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Profesion_ProfesionID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Profesion_ProfesionID");
            AddForeignKey("dbo.AspNetUsers", "Profesion_ProfesionID", "dbo.Profesions", "ProfesionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Profesion_ProfesionID", "dbo.Profesions");
            DropIndex("dbo.AspNetUsers", new[] { "Profesion_ProfesionID" });
            DropColumn("dbo.AspNetUsers", "Profesion_ProfesionID");
            DropColumn("dbo.AspNetUsers", "Age");
            DropTable("dbo.Profesions");
        }
    }
}
