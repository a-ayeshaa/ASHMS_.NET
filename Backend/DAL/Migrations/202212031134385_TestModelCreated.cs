namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Test_Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patient_Id = c.Int(nullable: false),
                        Reference = c.String(nullable: false),
                        Total = c.Single(nullable: false),
                        Status = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Report_Delivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.TestCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test_Id = c.Int(nullable: false),
                        Test_Transaction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Test_Transaction", t => t.Test_Transaction_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Test_Transaction_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCarts", "Test_Transaction_Id", "dbo.Test_Transaction");
            DropForeignKey("dbo.TestCarts", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.TestCarts", new[] { "Test_Transaction_Id" });
            DropIndex("dbo.TestCarts", new[] { "Test_Id" });
            DropIndex("dbo.Test_Transaction", new[] { "Patient_Id" });
            DropTable("dbo.Tests");
            DropTable("dbo.TestCarts");
            DropTable("dbo.Test_Transaction");
        }
    }
}
