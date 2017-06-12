namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecretKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "secretKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employes", "secretKey");
        }
    }
}
