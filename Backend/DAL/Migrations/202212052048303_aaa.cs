namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            AddColumn("dbo.Doctors", "Doctor_Id", c => c.Int());
            AddColumn("dbo.Doctors", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Doctors", "Doctor_Id");
            CreateIndex("dbo.Doctors", "Patient_Id");
            AddForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "Patient_Id" });
            DropIndex("dbo.Doctors", new[] { "Doctor_Id" });
            DropColumn("dbo.Doctors", "Patient_Id");
            DropColumn("dbo.Doctors", "Doctor_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
