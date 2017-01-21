namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationForBuild : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_EmployeeId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Employee_EmployeeId", newName: "Employee_Id");
            AddColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Employee_Id", c => c.String(maxLength: 128));
            DropPrimaryKey("dbo.Employees");
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.AspNetUsers", "Employee_Id");
            AddForeignKey("dbo.AspNetUsers", "Employee_Id", "dbo.Employees", "Id");
            DropColumn("dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUsers", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_Id" });
            DropPrimaryKey("dbo.Employees");
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            AlterColumn("dbo.AspNetUsers", "Employee_Id", c => c.Int());
            DropColumn("dbo.Employees", "Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "Employee_Id", newName: "Employee_EmployeeId");
            CreateIndex("dbo.AspNetUsers", "Employee_EmployeeId");
            AddForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
