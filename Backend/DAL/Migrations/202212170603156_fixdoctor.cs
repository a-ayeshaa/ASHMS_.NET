namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Doctor_Id", "dbo.Doctors");

        }
    }
}
