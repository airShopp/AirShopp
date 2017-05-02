namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddCustomerInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  SET IDENTITY_INSERT dbo.Customer ON
                    INSERT INTO Customer(Id,Account,Password,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                    VALUES(1,'Kenneth','202CB962AC59075B964B07152D234B70',GETUTCDATE(),NULL,13298312302,1,'KennethZhou',0);
                    INSERT INTO Customer(Id,Account,Password,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                    VALUES(2,'Jasper','202CB962AC59075B964B07152D234B70',GETUTCDATE(),NULL,13298312307,1,'JasperYue',0);
                    INSERT INTO Customer(Id,Account,Password,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                    VALUES(3,'Amanda','202CB962AC59075B964B07152D234B70',GETUTCDATE(),NULL,13298312275,0,'AmandaLi',0);
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Customer");
        }
    }
}
