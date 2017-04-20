namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCustomerDate : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO Customer(Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES('Kenneth','123',NULL,GETUTCDATE(),NULL,13298312302,1,'KennethZhou',0);

                INSERT INTO Customer(Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES('Jasper','123',NULL,GETUTCDATE(),NULL,13298312307,1,'JasperYue',0);

                INSERT INTO Customer(Account,Password,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerScore)
                VALUES('Amanda','123',NULL,GETUTCDATE(),NULL,13298312275,0,'AmandaLi',0);
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Customer");
        }
    }
}
