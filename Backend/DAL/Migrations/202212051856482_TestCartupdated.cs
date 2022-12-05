namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCartupdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Test_Transaction", new[] { "Patient_Id" });
            AddColumn("dbo.TestCarts", "Patient_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Test_Transaction", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Test_Transaction", "Patient_Id");
            CreateIndex("dbo.TestCarts", "Patient_Id");
            AddForeignKey("dbo.TestCarts", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.TestCarts", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.TestCarts", new[] { "Patient_Id" });
            DropIndex("dbo.Test_Transaction", new[] { "Patient_Id" });
            AlterColumn("dbo.Test_Transaction", "Patient_Id", c => c.Int(nullable: false));
            DropColumn("dbo.TestCarts", "Patient_Id");
            CreateIndex("dbo.Test_Transaction", "Patient_Id");
            AddForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
