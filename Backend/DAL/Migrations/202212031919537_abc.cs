namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patient_id = c.Int(nullable: false),
                        Total_Amount = c.Single(nullable: false),
                        Doctor_Charge = c.Single(nullable: false),
                        Hospital_Revenue = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
            AlterColumn("dbo.Test_Transaction", "Reference", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Test_Transaction", "Status", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Test_Transaction", "Report_Delivered", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Transactions", new[] { "Doctor_Id" });
            AlterColumn("dbo.Tests", "Name", c => c.String());
            AlterColumn("dbo.Test_Transaction", "Report_Delivered", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Test_Transaction", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Test_Transaction", "Reference", c => c.String(nullable: false));
            DropTable("dbo.Transactions");
        }
    }
}
