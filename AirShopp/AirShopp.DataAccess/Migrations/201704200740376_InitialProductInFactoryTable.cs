namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialProductInFactoryTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT dbo.ProductOutFactory ON
                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(1,1,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(2,1,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(3,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(4,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(5,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(6,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(7,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(8,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(9,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(10,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(11,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(12,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(13,1,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(14,1,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(15,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(16,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(17,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(18,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(19,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(20,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(21,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(22,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(23,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(24,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(25,2,GETUTCDATE());

                INSERT INTO ProductOutFactory(Id,Amount,OutDate)
                VALUES(26,2,GETUTCDATE());
  
                ");
        }
        
        public override void Down()
        {
        }
    }
}
