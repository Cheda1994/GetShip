namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_EmployeeId" });
            AddColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Employees");
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Employee_EmployeeId");
            DropColumn("dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AspNetUsers", "Employee_EmployeeId", c => c.Int());
            DropForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Employees");
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            DropColumn("dbo.Employees", "Id");
            CreateIndex("dbo.AspNetUsers", "Employee_EmployeeId");
            AddForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
