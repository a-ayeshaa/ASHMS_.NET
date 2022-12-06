namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmetnulladded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "startedAt", c => c.DateTime());
            AlterColumn("dbo.Appointments", "endedAt", c => c.DateTime());
            AlterColumn("dbo.Appointments", "revisit_count", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "revisit_count", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "endedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "startedAt", c => c.DateTime(nullable: false));
        }
    }
}
