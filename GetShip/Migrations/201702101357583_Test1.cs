namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employes", new[] { "Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employes", "Id");
            AddForeignKey("dbo.Employes", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
