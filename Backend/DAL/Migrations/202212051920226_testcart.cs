namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Test_Transaction", new[] { "Patient_Id" });
            AddColumn("dbo.TestCarts", "Patient_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TestCarts", "Patient_Id");
            AddForeignKey("dbo.TestCarts", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: false);
            DropColumn("dbo.Test_Transaction", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Test_Transaction", "Patient_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestCarts", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.TestCarts", new[] { "Patient_Id" });
            DropColumn("dbo.TestCarts", "Patient_Id");
            CreateIndex("dbo.Test_Transaction", "Patient_Id");
            AddForeignKey("dbo.Test_Transaction", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
