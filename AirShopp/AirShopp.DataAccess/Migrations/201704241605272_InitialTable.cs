namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceiverName = c.String(nullable: false, maxLength: 32),
                        ReceiverPhone = c.String(nullable: false, maxLength: 11),
                        DeliveryAddress = c.String(nullable: false, maxLength: 128),
                        IsDefault = c.Boolean(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        AreaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.AreaId);
            
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
                        AreaId = c.Long(nullable: false),
                        ParentStationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId)
                .ForeignKey("dbo.DeliveryStation", t => t.ParentStationId)
                .Index(t => t.AreaId)
                .Index(t => t.ParentStationId);
            
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
                "dbo.Customer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 32),
                        CustomerName = c.String(maxLength: 32),
                        ZipCode = c.String(maxLength: 6),
                        TelephoneNo = c.String(maxLength: 11),
                        Gender = c.Boolean(nullable: false),
                        CustomerScore = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PricePerProduct = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemStatus = c.String(),
                        ProductId = c.Long(nullable: false),
                        CartId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CartId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductionDate = c.DateTime(nullable: false),
                        KeepDate = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Url = c.String(),
                        IsOnSale = c.Boolean(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        ProviderId = c.Long(nullable: false),
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
                        ParentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Comments = c.String(nullable: false, maxLength: 256),
                        CommentDate = c.DateTime(nullable: false),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
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
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(nullable: false, maxLength: 32),
                        DeliveryDate = c.DateTime(nullable: false),
                        IsSpecialOrder = c.Boolean(nullable: false),
                        SpecialType = c.String(maxLength: 32),
                        CustomerId = c.Long(nullable: false),
                        AddressId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.DeliveryInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 512),
                        Index = c.Int(nullable: false),
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
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        ReturnReason = c.String(nullable: false, maxLength: 256),
                        ReturnStatus = c.String(nullable: false, maxLength: 32),
                        CustomerName = c.String(nullable: false, maxLength: 32),
                        OrderId = c.Long(nullable: false),
                        OrderItemId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.OrderItem", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Discounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        WarehouseId = c.Long(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.InventoryAction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductInFactoryId = c.Long(),
                        ProductOutFactoryId = c.Long(),
                        InventoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventory", t => t.InventoryId)
                .Index(t => t.InventoryId);
            
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
                "dbo.Admin",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
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
                "dbo.ProductInFactory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Price = c.String(nullable: false),
                        InDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOutFactory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        OutDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSales",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        SalesAmount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinceId = c.Long(nullable: false),
                        ProvinceName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Cart", "Id", "dbo.Customer");
            DropForeignKey("dbo.Product", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Inventory", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.InventoryAction", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Discount", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Comment", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Comment", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Return", "Id", "dbo.OrderItem");
            DropForeignKey("dbo.Return", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.DeliveryOrder", "Id", "dbo.Order");
            DropForeignKey("dbo.DeliveryOrderItem", "DeliveryOrderId", "dbo.DeliveryOrder");
            DropForeignKey("dbo.DeliveryNote", "Id", "dbo.Order");
            DropForeignKey("dbo.DeliveryInfo", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropForeignKey("dbo.Address", "AreaId", "dbo.Area");
            DropForeignKey("dbo.DeliveryStation", "ParentStationId", "dbo.DeliveryStation");
            DropForeignKey("dbo.Courier", "DeliveryStationId", "dbo.DeliveryStation");
            DropForeignKey("dbo.DeliveryStation", "AreaId", "dbo.Area");
            DropIndex("dbo.InventoryAction", new[] { "InventoryId" });
            DropIndex("dbo.Inventory", new[] { "WarehouseId" });
            DropIndex("dbo.Inventory", new[] { "ProductId" });
            DropIndex("dbo.Discount", new[] { "ProductId" });
            DropIndex("dbo.Return", new[] { "OrderId" });
            DropIndex("dbo.Return", new[] { "Id" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.DeliveryOrderItem", new[] { "DeliveryOrderId" });
            DropIndex("dbo.DeliveryOrder", new[] { "Id" });
            DropIndex("dbo.DeliveryNote", new[] { "Id" });
            DropIndex("dbo.DeliveryInfo", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Comment", new[] { "ProductId" });
            DropIndex("dbo.Comment", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "ProviderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.CartItem", new[] { "CartId" });
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropIndex("dbo.Cart", new[] { "Id" });
            DropIndex("dbo.Courier", new[] { "DeliveryStationId" });
            DropIndex("dbo.DeliveryStation", new[] { "ParentStationId" });
            DropIndex("dbo.DeliveryStation", new[] { "AreaId" });
            DropIndex("dbo.Address", new[] { "AreaId" });
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropTable("dbo.Province");
            DropTable("dbo.ProductSales");
            DropTable("dbo.ProductOutFactory");
            DropTable("dbo.ProductInFactory");
            DropTable("dbo.City");
            DropTable("dbo.Admin");
            DropTable("dbo.Provider");
            DropTable("dbo.Warehouse");
            DropTable("dbo.InventoryAction");
            DropTable("dbo.Inventory");
            DropTable("dbo.Discount");
            DropTable("dbo.Return");
            DropTable("dbo.OrderItem");
            DropTable("dbo.DeliveryOrderItem");
            DropTable("dbo.DeliveryOrder");
            DropTable("dbo.DeliveryNote");
            DropTable("dbo.DeliveryInfo");
            DropTable("dbo.Order");
            DropTable("dbo.Comment");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
            DropTable("dbo.Cart");
            DropTable("dbo.Customer");
            DropTable("dbo.Courier");
            DropTable("dbo.DeliveryStation");
            DropTable("dbo.Area");
            DropTable("dbo.Address");
        }
    }
}
