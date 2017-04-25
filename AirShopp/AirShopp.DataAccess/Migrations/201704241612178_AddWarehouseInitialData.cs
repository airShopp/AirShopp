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
                 VALUES(1,'上海1号仓库',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(2,'上海2号仓库',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(3,'上海3号仓库',1);
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(4,'上海4号仓库',1);
     
                 INSERT INTO Warehouse(Id,Name,IsUsed)
                 VALUES(5,'上海5号仓库',1);
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Warehouse");
        }
    }
}
