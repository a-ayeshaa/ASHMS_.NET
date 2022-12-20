namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tokentableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        token = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        expiredAt = c.DateTime(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "User_Id", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "User_Id" });
            DropTable("dbo.Tokens");
        }
    }
}
