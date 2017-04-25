namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddWarehouseInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                 SET IDENTITY_INSERT dbo.Warehouse ON
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(1,'�Ϻ�1�Ųֿ�',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(2,'�Ϻ�2�Ųֿ�',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(3,'�Ϻ�3�Ųֿ�',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(4,'�Ϻ�4�Ųֿ�',1);
     
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(5,'�Ϻ�5�Ųֿ�',1);
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Warehouse");
        }
    }
}
