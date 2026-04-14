namespace WarehouseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionHistories",
                c => new
                    {
                        IdAction = c.Guid(nullable: false),
                        EventData = c.DateTime(nullable: false),
                        Action = c.String(),
                        Details = c.String(),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdAction)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Login = c.String(),
                        HashPassword = c.String(),
                        Role = c.Int(nullable: false),
                        DateOfRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategories = c.Guid(nullable: false),
                        NameCategory = c.String(),
                    })
                .PrimaryKey(t => t.IdCategories);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClients = c.Guid(nullable: false),
                        NameClients = c.String(),
                    })
                .PrimaryKey(t => t.IdClients);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProducts = c.Guid(nullable: false),
                        Article = c.Guid(nullable: false),
                        NameProduct = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdCategories = c.Guid(nullable: false),
                        IdUnitOfMeasure = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducts)
                .ForeignKey("dbo.Categories", t => t.IdCategories, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfMeasures", t => t.IdUnitOfMeasure, cascadeDelete: true)
                .Index(t => t.IdCategories)
                .Index(t => t.IdUnitOfMeasure);
            
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        IdUnit = c.Guid(nullable: false),
                        NameUnit = c.String(),
                    })
                .PrimaryKey(t => t.IdUnit);
            
            CreateTable(
                "dbo.ShipmentContents",
                c => new
                    {
                        IdShipmentContents = c.Guid(nullable: false),
                        QuantityShipmentContents = c.Int(nullable: false),
                        PriceShipmentContents = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdShipment = c.Guid(nullable: false),
                        IdProducts = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdShipmentContents)
                .ForeignKey("dbo.Products", t => t.IdProducts, cascadeDelete: true)
                .ForeignKey("dbo.Shipments", t => t.IdShipment, cascadeDelete: true)
                .Index(t => t.IdShipment)
                .Index(t => t.IdProducts);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        IdShipment = c.Guid(nullable: false),
                        DateOfShipment = c.DateTime(nullable: false),
                        PriceShipment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        IdClients = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdShipment)
                .ForeignKey("dbo.Clients", t => t.IdClients, cascadeDelete: true)
                .Index(t => t.IdClients);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentContents", "IdShipment", "dbo.Shipments");
            DropForeignKey("dbo.Shipments", "IdClients", "dbo.Clients");
            DropForeignKey("dbo.ShipmentContents", "IdProducts", "dbo.Products");
            DropForeignKey("dbo.Products", "IdUnitOfMeasure", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.Products", "IdCategories", "dbo.Categories");
            DropForeignKey("dbo.ActionHistories", "Id", "dbo.Users");
            DropIndex("dbo.Shipments", new[] { "IdClients" });
            DropIndex("dbo.ShipmentContents", new[] { "IdProducts" });
            DropIndex("dbo.ShipmentContents", new[] { "IdShipment" });
            DropIndex("dbo.Products", new[] { "IdUnitOfMeasure" });
            DropIndex("dbo.Products", new[] { "IdCategories" });
            DropIndex("dbo.ActionHistories", new[] { "Id" });
            DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentContents");
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.ActionHistories");
        }
    }
}
