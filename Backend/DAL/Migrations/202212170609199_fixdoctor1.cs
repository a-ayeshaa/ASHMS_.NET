namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdoctor1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "Doctor_Id" });
            //AddForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
            DropColumn("dbo.Doctors", "Doctor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Doctor_Id", c => c.Int());
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            CreateIndex("dbo.Doctors", "Doctor_Id");
            AddForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
