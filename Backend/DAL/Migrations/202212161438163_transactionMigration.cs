namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Transactions", new[] { "Doctor_Id" });
            AlterColumn("dbo.Transactions", "Doctor_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Patient_id");
            CreateIndex("dbo.Transactions", "Doctor_id");
            AddForeignKey("dbo.Transactions", "Patient_id", "dbo.Patients", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Transactions", "Doctor_id", "dbo.Doctors", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Doctor_id", "dbo.Doctors");
            DropForeignKey("dbo.Transactions", "Patient_id", "dbo.Patients");
            DropIndex("dbo.Transactions", new[] { "Doctor_id" });
            DropIndex("dbo.Transactions", new[] { "Patient_id" });
            AlterColumn("dbo.Transactions", "Doctor_id", c => c.Int());
            CreateIndex("dbo.Transactions", "Doctor_Id");
            AddForeignKey("dbo.Transactions", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
