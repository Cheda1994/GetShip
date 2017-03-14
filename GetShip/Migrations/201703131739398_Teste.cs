namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Selaries", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Selaries", "Date", c => c.DateTime(nullable: false));
        }
    }
}
