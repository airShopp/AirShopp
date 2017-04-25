namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[OrderItem] ON 
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (1, CAST(200.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), 1, 1, 1)
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (2, CAST(200.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 1, 1, 2)
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (3, CAST(200.00 AS Decimal(18, 2)), CAST(62.00 AS Decimal(18, 2)), 1, 1, 3)
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (4, CAST(200.00 AS Decimal(18, 2)), CAST(82.00 AS Decimal(18, 2)), 1, 2, 4)
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (5, CAST(200.00 AS Decimal(18, 2)), CAST(102.00 AS Decimal(18, 2)), 1, 2, 5)
                    INSERT [dbo].[OrderItem] ([Id], [UnitPrice], [DiscountPrice], [Quantity], [OrderId], [ProductId]) 
                    VALUES (6, CAST(200.00 AS Decimal(18, 2)), CAST(122.00 AS Decimal(18, 2)), 1, 2, 6)
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.OrderItem");
        }
    }
}
