namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddOrderInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT  [dbo]. [Order] ON
                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(1,1,29.9,getdate(),1,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(2,1,39.9,getdate(),1,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(3,1,49.9,getdate(),2,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(4,1,59.9,getdate(),2,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(5,1,69.9,getdate(),3,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(6,1,79.9,getdate(),3,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(7,1,89.9,getdate(),4,'',1,0,'');

                    INSERT INTO [Order](Id,CustomerId,TotalAmount,OrderDate,OrderStatus,DeliveryDate,AddressId,IsSpecialOrder,SpecialType)
                    VALUES(8,1,99.9,getdate(),4,'',1,0,'');
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Order");
        }
    }
}
