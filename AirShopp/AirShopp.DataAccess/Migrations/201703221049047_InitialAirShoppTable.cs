namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAirShoppTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IsBuy = c.Boolean(nullable: false),
                        ProductTotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        CustomerCode = c.String(),
                        Address = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        ZipCode = c.String(),
                        TelephoneNo = c.String(),
                        Gender = c.Boolean(nullable: false),
                        CustomerName = c.String(),
                        CustomerLevel = c.String(),
                        CustomerScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryId = c.Long(nullable: false),
                        ProviderId = c.Long(nullable: false),
                        Storage = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        KeepDate = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supply = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.CategoryId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProviderName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ZipCode = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerLevel = c.String(),
                        Discounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ScoreRequire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductIn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.String(nullable: false),
                        InDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductOut",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Amount = c.Int(nullable: false),
                        OutDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        ReturnReason = c.String(),
                        ProductId = c.String(),
                        Quantity = c.Int(nullable: false),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Return", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductOut", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductIn", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Delivery", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Delivery", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Cart", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Return", new[] { "OrderId" });
            DropIndex("dbo.ProductOut", new[] { "ProductId" });
            DropIndex("dbo.ProductIn", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Delivery", new[] { "ProductId" });
            DropIndex("dbo.Delivery", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "ProviderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropIndex("dbo.Cart", new[] { "CustomerId" });
            DropTable("dbo.Return");
            DropTable("dbo.ProductOut");
            DropTable("dbo.ProductIn");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Discount");
            DropTable("dbo.Order");
            DropTable("dbo.Delivery");
            DropTable("dbo.Provider");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Customer");
            DropTable("dbo.Cart");
            DropTable("dbo.Admin");
        }
    }
}
