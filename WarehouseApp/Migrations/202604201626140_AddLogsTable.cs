
namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CurrentUser_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "CurrentUser_Id" });
            CreateTable(
                "dbo.SystemLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Level = c.Int(nullable: false),
                        Action = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "CurrentUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CurrentUser_Id", c => c.Guid());
            DropTable("dbo.SystemLogs");
            CreateIndex("dbo.Users", "CurrentUser_Id");
            AddForeignKey("dbo.Users", "CurrentUser_Id", "dbo.Users", "Id");
        }
    }
}
