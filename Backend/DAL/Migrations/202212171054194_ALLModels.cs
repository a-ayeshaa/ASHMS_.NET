namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALLModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Revenue = c.Single(nullable: false),
                        Transaction_type = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        startedAt = c.DateTime(),
                        endedAt = c.DateTime(),
                        status = c.String(nullable: false, maxLength: 50),
                        revisit_count = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Specialization = c.String(nullable: false, maxLength: 100),
                        Degree = c.String(nullable: false, maxLength: 100),
                        VisitingDays = c.String(nullable: false, maxLength: 100),
                        Appointment_Fees = c.Single(nullable: false),
                        Net_Earnings = c.Single(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 50),
                        Role = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegisteredAt = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Phone = c.String(maxLength: 15),
                        BloodGroup = c.String(nullable: false, maxLength: 3),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TestCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test_Id = c.Int(nullable: false),
                        Test_Transaction_Id = c.Int(),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestTransactions", t => t.Test_Transaction_Id)
                .Index(t => t.Test_Id)
                .Index(t => t.Test_Transaction_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(nullable: false, maxLength: 50),
                        Total = c.Single(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Report_Delivered = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Appointment_Id = c.Int(nullable: false),
                        Total_Amount = c.Single(nullable: false),
                        Doctor_Charge = c.Single(nullable: false),
                        Hospital_Revenue = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Appointment_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Appointment_Id = c.Int(nullable: false),
                        Chief_complaint = c.String(),
                        On_evaluation = c.String(),
                        Deduction = c.String(),
                        Advancement = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id, cascadeDelete: true)
                .Index(t => t.Appointment_Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Chemical_Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Patients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Transactions", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.TestCarts", "Test_Transaction_Id", "dbo.TestTransactions");
            DropForeignKey("dbo.TestCarts", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.TestCarts", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "Appointment_Id" });
            DropIndex("dbo.Transactions", new[] { "Patient_Id" });
            DropIndex("dbo.Transactions", new[] { "Appointment_Id" });
            DropIndex("dbo.TestCarts", new[] { "Patient_Id" });
            DropIndex("dbo.TestCarts", new[] { "Test_Transaction_Id" });
            DropIndex("dbo.TestCarts", new[] { "Test_Id" });
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropTable("dbo.Medicines");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Transactions");
            DropTable("dbo.TestTransactions");
            DropTable("dbo.Tests");
            DropTable("dbo.TestCarts");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
            DropTable("dbo.Accounts");
        }
    }
}
