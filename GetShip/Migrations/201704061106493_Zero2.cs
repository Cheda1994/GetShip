namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zero2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galeries", "DateUploaded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galeries", "DateUploaded", c => c.DateTime(nullable: false));
        }
    }
}
