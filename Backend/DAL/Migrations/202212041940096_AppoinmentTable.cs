namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppoinmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        startedAt = c.DateTime(nullable: false),
                        endedAt = c.DateTime(nullable: false),
                        status = c.String(nullable: false, maxLength: 50),
                        revisit_count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropTable("dbo.Appointments");
        }
    }
}
