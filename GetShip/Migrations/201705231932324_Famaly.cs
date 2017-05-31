namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Famaly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Age = c.Int(),
                        Role = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Avatar_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galeries", t => t.Avatar_Id)
                .Index(t => t.Avatar_Id);
            
            CreateTable(
                "dbo.Galeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                        DateUploaded = c.DateTime(),
                        Description = c.String(),
                        Type = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CurrentLocation = c.String(),
                        CurrendWather_Id = c.Int(),
                        Profesion_Id = c.Int(),
                        Company_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Wathers", t => t.CurrendWather_Id)
                .ForeignKey("dbo.Profesions", t => t.Profesion_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Id)
                .Index(t => t.CurrendWather_Id)
                .Index(t => t.Profesion_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Wathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Int(nullable: false),
                        WatherStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Famalies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelaryAcsess = c.Boolean(nullable: false),
                        WetherAcsess = c.Boolean(nullable: false),
                        LocationAcsess = c.Boolean(nullable: false),
                        GaleryAcsess = c.Boolean(nullable: false),
                        Employe_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employes", t => t.Employe_Id)
                .Index(t => t.Employe_Id);
            
            CreateTable(
                "dbo.Profesions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Selaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Count = c.Double(nullable: false),
                        Employe_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employes", t => t.Employe_Id, cascadeDelete: true)
                .Index(t => t.Employe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Galeries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Selaries", "Employe_Id", "dbo.Employes");
            DropForeignKey("dbo.Employes", "Profesion_Id", "dbo.Profesions");
            DropForeignKey("dbo.Famalies", "Employe_Id", "dbo.Employes");
            DropForeignKey("dbo.Employes", "CurrendWather_Id", "dbo.Wathers");
            DropForeignKey("dbo.Employes", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Avatar_Id", "dbo.Galeries");
            DropIndex("dbo.Employes", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "Id" });
            DropIndex("dbo.Galeries", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Selaries", new[] { "Employe_Id" });
            DropIndex("dbo.Employes", new[] { "Profesion_Id" });
            DropIndex("dbo.Famalies", new[] { "Employe_Id" });
            DropIndex("dbo.Employes", new[] { "CurrendWather_Id" });
            DropIndex("dbo.Employes", new[] { "Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Avatar_Id" });
            DropTable("dbo.Selaries");
            DropTable("dbo.Profesions");
            DropTable("dbo.Famalies");
            DropTable("dbo.Wathers");
            DropTable("dbo.Employes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Galeries");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
        }
    }
}
