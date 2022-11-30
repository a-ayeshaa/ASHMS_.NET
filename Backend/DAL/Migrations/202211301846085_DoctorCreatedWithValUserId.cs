namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorCreatedWithValUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "UserId");
            AddForeignKey("dbo.Doctors", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropColumn("dbo.Doctors", "UserId");
        }
    }
}
