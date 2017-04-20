namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCartDate : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT dbo.Cart ON
                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(1,2,1,100,80,5,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(2,3,2,100,80,2,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(3,4,3,100,80,3,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(4,2,4,100,80,6,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(5,3,5,100,80,12,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(6,4,6,100,80,1,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(7,4,7,100,80,2,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(8,3,8,100,80,3,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(9,2,9,100,80,1,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(10,2,10,100,80,5,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(11,3,11,100,80,3,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(12,4,12,100,80,7,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(13,2,13,100,80,2,1);

                INSERT INTO Cart(Id,CustomerId, ProductId,UnitPrice,DiscountPrice,Quantity,IsBuy)
                VALUES(14,3,14,100,80,9,1);    
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Cart;");
        }
    }
}
