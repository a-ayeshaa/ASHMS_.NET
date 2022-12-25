
namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemedicine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medicines", "Description", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Medicines", "Name");
        }
    }
}
