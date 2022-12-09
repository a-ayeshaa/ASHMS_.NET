namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prescription : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id, cascadeDelete: false)
                .Index(t => t.Appointment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Prescriptions", new[] { "Appointment_Id" });
            DropTable("dbo.Prescriptions");
        }
    }
}
