namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Order] ON 
                    INSERT [dbo].[Order] ([Id], [TotalAmount], [OrderDate], [OrderStatus], [DeliveryDate], [IsSpecialOrder], [SpecialType], [CustomerId], [AddressId])
                    VALUES (1, CAST(126.00 AS Decimal(18, 2)), CAST(N'2017-04-24 22:05:00.000' AS DateTime), N'OBLIGATION', CAST(N'1970-01-01 00:00:00.000' AS DateTime), 0, NULL, 1, 1)
                    INSERT [dbo].[Order] ([Id], [TotalAmount], [OrderDate], [OrderStatus], [DeliveryDate], [IsSpecialOrder], [SpecialType], [CustomerId], [AddressId])
                    VALUES (2, CAST(306.00 AS Decimal(18, 2)), CAST(N'2017-04-24 22:55:00.000' AS DateTime), N'OBLIGATION', CAST(N'1970-01-01 00:00:00.000' AS DateTime), 0, NULL, 2, 2)
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.[Order]");
        }
    }
}
