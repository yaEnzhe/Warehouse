namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppSettingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppSettings");
        }
    }
}
