namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpirationFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CurrentUser_Id", c => c.Guid());
            CreateIndex("dbo.Users", "CurrentUser_Id");
            AddForeignKey("dbo.Users", "CurrentUser_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CurrentUser_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "CurrentUser_Id" });
            DropColumn("dbo.Users", "CurrentUser_Id");
        }
    }
}
