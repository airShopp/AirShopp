namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProductSalesData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT dbo.ProductSales ON
                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(1,1,3,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(2,2,7,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(3,4,2,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(4,5,6,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(5,6,4,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(6,8,2,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(7,64,2,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(8,24,1,GETUTCDATE(),GETUTCDATE());


                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(9,22,1,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(10,12,4,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(11,45,4,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(12,12,4,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(13,34,2,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(14,21,2,GETUTCDATE(),GETUTCDATE());

                INSERT INTO ProductSales(Id,ProductId,SalesAmount,CreateDate,UpdateDate)
                VALUES(15,15,2,GETUTCDATE(),GETUTCDATE());
                    ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.ProductSales");
        }
    }
}
