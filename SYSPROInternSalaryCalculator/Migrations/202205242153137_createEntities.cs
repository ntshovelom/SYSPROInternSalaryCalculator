namespace SYSPROInternSalaryCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        IDNumber = c.String(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RatePerHour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        Intern_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interns", t => t.Intern_Id)
                .Index(t => t.Intern_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Intern_Id", "dbo.Interns");
            DropForeignKey("dbo.Interns", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Tasks", new[] { "Intern_Id" });
            DropIndex("dbo.Interns", new[] { "Role_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Roles");
            DropTable("dbo.Interns");
        }
    }
}
