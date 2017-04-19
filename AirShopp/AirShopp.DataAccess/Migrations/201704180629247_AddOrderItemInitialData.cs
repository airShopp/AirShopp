namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemInitialData : DbMigration
    {

        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT[dbo].[OrderItem] ON
                    INSERT INTO[OrderItem](Id,OrderId,ProductId,UnitPrice,DiscountPrice,Quantity,OrderDate)
                    VALUES(1,1,1,200,9.9,1,getdate());
                    INSERT INTO[OrderItem](Id,OrderId,ProductId,UnitPrice,DiscountPrice,Quantity,OrderDate)
                    VALUES(2,2,2,200,9.9,1,getdate());
                    INSERT INTO[OrderItem](Id,OrderId,ProductId,UnitPrice,DiscountPrice,Quantity,OrderDate)
                    VALUES(3,2,3,200,10,2,getdate());
                ");

        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.OrderItem");
        }
    }
}
