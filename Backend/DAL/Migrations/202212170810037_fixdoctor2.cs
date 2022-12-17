namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdoctor2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Doctors", new[] { "Patient_Id" });
            //AddForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
            DropColumn("dbo.Doctors", "Patient_Id");
        }
        
        public override void Down()
        {
        }
    }
}
