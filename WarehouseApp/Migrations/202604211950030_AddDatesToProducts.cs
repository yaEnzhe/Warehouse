namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesToProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ExpirationDate", c => c.DateTime());
            AddColumn("dbo.Products", "ProductionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductionDate");
            DropColumn("dbo.Products", "ExpirationDate");
        }
    }
}
