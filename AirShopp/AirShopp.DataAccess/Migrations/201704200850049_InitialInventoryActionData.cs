namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialInventoryActionData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.InventoryAction ON
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(1,NULL,1,1);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(2,NULL,2,2);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(3,NULL,3,1);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(4,NULL,4,3);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(5,NULL,5,2);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(6,NULL,6,6);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(7,NULL,7,5);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(8,NULL,8,8);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(9,NULL,9,3);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(10,NULL,10,4);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(11,NULL,11,5);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(12,NULL,12,64);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(13,NULL,13,24);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(14,NULL,14,22);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(15,NULL,15,12);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(16,NULL,16,3);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(17,NULL,17,45);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(18,NULL,18,45);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(19,NULL,19,2);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(20,NULL,20,5);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(21,NULL,21,2);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(22,NULL,22,34);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(23,NULL,23,12);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(24,NULL,24,6);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(25,NULL,25,21);
                    INSERT INTO InventoryAction(Id,ProductInFactoryId,ProductOutFactoryId,InventoryId) VALUES(26,NULL,26,15);
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.InventoryAction");
        }
    }
}
