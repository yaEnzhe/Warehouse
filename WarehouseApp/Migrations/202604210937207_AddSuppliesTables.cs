
namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuppliesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplyItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SupplyId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.SupplyId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyItems", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.SupplyItems", "ProductId", "dbo.Products");
            DropIndex("dbo.SupplyItems", new[] { "ProductId" });
            DropIndex("dbo.SupplyItems", new[] { "SupplyId" });
            DropTable("dbo.SupplyItems");
            DropTable("dbo.Supplies");
        }
    }
}
