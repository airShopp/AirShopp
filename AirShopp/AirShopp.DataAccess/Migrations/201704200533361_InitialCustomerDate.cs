namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCustomerDate : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  SET IDENTITY_INSERT dbo.Customer ON
                INSERT INTO Customer(Id,Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES(2,'Kenneth','123',NULL,GETUTCDATE(),NULL,13298312302,1,'KennethZhou',0);

                INSERT INTO Customer(Id,Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES(3,'Jasper','123',NULL,GETUTCDATE(),NULL,13298312307,1,'JasperYue',0);

                INSERT INTO Customer(Id,Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES(4,'Amanda','123',NULL,GETUTCDATE(),NULL,13298312275,0,'AmandaLi',0);
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Customer");
        }
    }
}
