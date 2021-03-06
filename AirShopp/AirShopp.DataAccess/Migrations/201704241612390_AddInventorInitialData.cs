namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddInventorInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Inventory ON
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(1,1,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(2,2,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(3,3,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(4,4,4,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(5,5,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(6,6,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(7,7,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(8,8,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(9,9,4,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(10,10,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(11,11,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(12,12,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(13,13,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(14,14,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(15,15,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(16,16,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(17,17,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(18,18,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(19,19,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(20,20,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(21,21,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(22,22,4,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(23,23,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(24,24,4,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(25,25,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(26,26,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(27,27,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(28,28,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(29,29,4,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(30,30,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(31,31,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(32,32,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(33,33,3,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(34,34,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(35,35,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(36,36,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(37,37,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(38,38,5,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(39,39,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(40,40,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(41,41,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(42,42,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(43,43,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(44,44,2,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(45,45,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(46,46,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(47,47,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(48,48,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(49,49,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(50,50,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(51,51,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(52,52,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(53,53,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(54,54,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(55,55,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(56,56,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(57,57,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(58,58,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(59,59,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(60,60,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(61,61,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(62,62,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(63,63,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(64,64,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(65,65,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(66,66,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(67,67,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(68,68,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(69,69,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(70,70,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(71,71,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(72,72,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(73,73,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(74,74,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(75,75,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(76,76,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(77,77,1,20);
                    INSERT INTO Inventory(Id, ProductId,WarehouseId,Amount) VALUES(78,78,1,20);
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Inventory");
        }
    }
}
