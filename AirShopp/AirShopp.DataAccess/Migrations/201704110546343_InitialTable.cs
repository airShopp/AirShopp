namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTable : DbMigration
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
                "dbo.Area",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AreaId = c.Long(nullable: false),
                        AreaName = c.String(nullable: false, maxLength: 256),
                        CityId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryStation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Address = c.String(nullable: false, maxLength: 64),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        StationLevel = c.Int(nullable: false),
                        ParentStationId = c.Long(nullable: false),
                        AreaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId)
                .ForeignKey("dbo.DeliveryStation", t => t.ParentStationId)
                .Index(t => t.ParentStationId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Courier",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Phone = c.String(nullable: false, maxLength: 11),
                        DeliveryStationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryStation", t => t.DeliveryStationId)
                .Index(t => t.DeliveryStationId);
            
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
                "dbo.DeliveryInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 512),
                        CurrentLocation = c.String(nullable: false, maxLength: 64),
                        UpdateTime = c.DateTime(nullable: false),
                        OrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.DeliveryNote",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeliveryNoteNumber = c.String(nullable: false, maxLength: 20),
                        BarCodeImgURL = c.String(nullable: false, maxLength: 512),
                        QRCodeImgURL = c.String(nullable: false, maxLength: 512),
                        Remarks = c.String(maxLength: 512),
                        OrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryOrder",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeliveryOrderNumber = c.String(nullable: false, maxLength: 20),
                        DeliveryDate = c.DateTime(nullable: false),
                        TotalRMBInChinese = c.String(nullable: false, maxLength: 50),
                        TotalRMBInNumberic = c.String(nullable: false, maxLength: 50),
                        OrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryOrderItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 256),
                        Unit = c.String(nullable: false, maxLength: 8),
                        OutNumber = c.Int(nullable: false),
                        PricePerProduct = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 512),
                        DeliveryOrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryOrder", t => t.DeliveryOrderId)
                .Index(t => t.DeliveryOrderId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Long(nullable: false),
                        ProviderId = c.Long(nullable: false),
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
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        FactoryId = c.Long(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouse", t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsUsed = c.Boolean(nullable: false),
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
                "dbo.City",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityId = c.Long(nullable: false),
                        CityName = c.String(nullable: false, maxLength: 256),
                        ProvinceId = c.Long(nullable: false),
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
                "dbo.InventoryAction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductInFactoryId = c.Long(nullable: false),
                        ProductOutFactoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInFactory", t => t.ProductInFactoryId)
                .ForeignKey("dbo.ProductOutFactory", t => t.ProductOutFactoryId)
                .Index(t => t.ProductInFactoryId)
                .Index(t => t.ProductOutFactoryId);
            
            CreateTable(
                "dbo.ProductInFactory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Price = c.String(nullable: false),
                        InDate = c.DateTime(nullable: false),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOutFactory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        OutDate = c.DateTime(nullable: false),
                        ProductName = c.String(),
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
                "dbo.Province",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinceId = c.Long(nullable: false),
                        ProvinceName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.InventoryAction", "ProductOutFactoryId", "dbo.ProductOutFactory");
            DropForeignKey("dbo.InventoryAction", "ProductInFactoryId", "dbo.ProductInFactory");
            DropForeignKey("dbo.Delivery", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Delivery", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Warehouse");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Cart", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.DeliveryOrder", "Id", "dbo.Order");
            DropForeignKey("dbo.DeliveryOrderItem", "DeliveryOrderId", "dbo.DeliveryOrder");
            DropForeignKey("dbo.DeliveryNote", "Id", "dbo.Order");
            DropForeignKey("dbo.DeliveryInfo", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.DeliveryStation", "ParentStationId", "dbo.DeliveryStation");
            DropForeignKey("dbo.Courier", "DeliveryStationId", "dbo.DeliveryStation");
            DropForeignKey("dbo.DeliveryStation", "AreaId", "dbo.Area");
            DropIndex("dbo.Return", new[] { "OrderId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.InventoryAction", new[] { "ProductOutFactoryId" });
            DropIndex("dbo.InventoryAction", new[] { "ProductInFactoryId" });
            DropIndex("dbo.Delivery", new[] { "ProductId" });
            DropIndex("dbo.Delivery", new[] { "OrderId" });
            DropIndex("dbo.Inventory", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "ProviderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.DeliveryOrderItem", new[] { "DeliveryOrderId" });
            DropIndex("dbo.DeliveryOrder", new[] { "Id" });
            DropIndex("dbo.DeliveryNote", new[] { "Id" });
            DropIndex("dbo.DeliveryInfo", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropIndex("dbo.Cart", new[] { "CustomerId" });
            DropIndex("dbo.Courier", new[] { "DeliveryStationId" });
            DropIndex("dbo.DeliveryStation", new[] { "AreaId" });
            DropIndex("dbo.DeliveryStation", new[] { "ParentStationId" });
            DropTable("dbo.Return");
            DropTable("dbo.Province");
            DropTable("dbo.OrderItem");
            DropTable("dbo.ProductOutFactory");
            DropTable("dbo.ProductInFactory");
            DropTable("dbo.InventoryAction");
            DropTable("dbo.Discount");
            DropTable("dbo.Delivery");
            DropTable("dbo.City");
            DropTable("dbo.Provider");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Inventory");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.DeliveryOrderItem");
            DropTable("dbo.DeliveryOrder");
            DropTable("dbo.DeliveryNote");
            DropTable("dbo.DeliveryInfo");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.Cart");
            DropTable("dbo.Courier");
            DropTable("dbo.DeliveryStation");
            DropTable("dbo.Area");
            DropTable("dbo.Admin");
        }
    }
}
