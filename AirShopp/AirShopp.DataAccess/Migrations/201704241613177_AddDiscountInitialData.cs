namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDiscountInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Discount ON
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(1,1.1,1,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(2,2.1,2,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(3,3.1,3,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(4,4.1,4,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(5,5.1,5,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(6,1.2,6,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(7,2.2,7,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(8,3.2,8,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(9,4.2,9,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(10,5.2,10,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(11,6.2,11,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(12,7.2,12,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(13,8.2,13,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(14,1.8,14,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(15,2.8,15,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(16,3.8,16,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(17,4.8,17,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(18,5.8,18,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(19,6.8,19,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(20,7.8,20,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(21,8.8,21,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(22,9.8,22,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(23,1.5,23,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(24,2.5,24,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(25,3.5,25,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(26,4.5,26,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(27,5.5,27,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(28,6.5,28,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(29,7.5,29,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(30,8.5,30,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(31,9.5,31,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(32,1.9,32,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(33,2.9,33,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(34,3.9,34,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(35,4.9,35,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(36,5.9,36,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(37,6.9,37,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(38,7.9,38,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(39,8.9,39,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(40,1.4,40,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(41,2.4,41,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(42,3.4,42,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(43,4.4,43,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(44,5.4,44,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(45,6.4,45,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(46,7.4,46,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(47,8.4,47,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(48,1,48,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(49,2,49,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(50,3,50,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(51,4,51,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(52,5,52,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(53,6,53,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(54,7,54,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(55,8,55,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(56,2,56,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(57,3,57,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(58,4,58,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(59,3,59,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(60,4,60,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(61,5,61,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(62,6,62,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(63,1.6,63,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(64,2.6,64,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(65,3.6,65,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(66,4.6,66,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(67,5.6,67,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(68,6.6,68,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(69,7.6,69,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(70,8.6,70,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(71,9.6,71,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(72,1.7,72,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(73,2.7,73,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(74,3.7,74,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(75,4.7,75,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(76,5.7,76,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(77,6.7,77,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
                    INSERT INTO Discount(Id,Discounts,ProductId,StartTime,EndTime,IsUsed) VALUES(78,7.7,78,GETUTCDATE(),CONVERT(DATETIME, '2017-6-14 14:10',120),1);
        ");
        } 
        
        public override void Down()
        {
             Sql(@"DELETE FROM dbo.Discount");
        }
    }
}
