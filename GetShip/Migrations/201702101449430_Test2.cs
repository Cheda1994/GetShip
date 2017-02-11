namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employes", "Id");
            AddForeignKey("dbo.Employes", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employes", new[] { "Id" });
        }
    }
}
