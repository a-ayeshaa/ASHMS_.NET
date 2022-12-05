namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            AlterColumn("dbo.Appointments", "Patient_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Patient_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            AlterColumn("dbo.Appointments", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Patient_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
