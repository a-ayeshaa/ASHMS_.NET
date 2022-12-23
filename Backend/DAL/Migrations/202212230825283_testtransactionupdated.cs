namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testtransactionupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestTransactions", "Patient_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TestTransactions", "Patient_Id");
            AddForeignKey("dbo.TestTransactions", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestTransactions", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.TestTransactions", new[] { "Patient_Id" });
            DropColumn("dbo.TestTransactions", "Patient_Id");
        }
    }
}
