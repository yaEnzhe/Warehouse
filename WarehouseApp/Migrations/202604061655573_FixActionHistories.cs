namespace WarehouseApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixActionHistories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Article", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Article", c => c.Guid(nullable: false));
        }
    }
}
