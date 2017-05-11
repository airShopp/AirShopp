namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductOutFactoryInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT dbo.ProductOutFactory ON
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(1,1,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(2,1,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(3,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(4,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(5,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(6,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(7,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(8,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(9,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(10,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(11,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(12,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(13,1,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(14,1,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(15,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(16,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(17,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(18,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(19,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(20,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(21,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(22,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(23,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(24,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(25,2,GETUTCDATE(), 100, 1);
                INSERT INTO ProductOutFactory(Id,Amount,OutDate, UnitPrice, CustomerId)
                VALUES(26,2,GETUTCDATE(), 100, 1);
  
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.ProductOutFactory");
        }
    }
}
