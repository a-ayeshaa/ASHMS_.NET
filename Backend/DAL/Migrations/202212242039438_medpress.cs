namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medpress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicinePrescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prescription_Id = c.Int(nullable: false),
                        Medicine_Id = c.Int(nullable: false),
                        Doze = c.String(),
                        Continuation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedicinePrescriptions");
        }
    }
}
