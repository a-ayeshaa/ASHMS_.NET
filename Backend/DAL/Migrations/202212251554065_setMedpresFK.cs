namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setMedpresFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicinePrescriptions", "Prescription_Id");
            AddForeignKey("dbo.MedicinePrescriptions", "Prescription_Id", "dbo.Prescriptions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicinePrescriptions", "Prescription_Id", "dbo.Prescriptions");
            DropIndex("dbo.MedicinePrescriptions", new[] { "Prescription_Id" });
        }
    }
}
