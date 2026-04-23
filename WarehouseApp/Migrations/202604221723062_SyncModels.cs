
namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncModels : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SystemLogs");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
