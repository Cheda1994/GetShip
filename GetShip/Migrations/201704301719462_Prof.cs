namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prof : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profesions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employes", "Profesion_Id", c => c.Int());
            CreateIndex("dbo.Employes", "Profesion_Id");
            AddForeignKey("dbo.Employes", "Profesion_Id", "dbo.Profesions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Profesion_Id", "dbo.Profesions");
            DropIndex("dbo.Employes", new[] { "Profesion_Id" });
            DropColumn("dbo.Employes", "Profesion_Id");
            DropTable("dbo.Profesions");
        }
    }
}
