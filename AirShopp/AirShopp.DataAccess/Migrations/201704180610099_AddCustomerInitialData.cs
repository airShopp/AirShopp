namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT[dbo].[Customer] ON
                    INSERT INTO[Customer](Id,Account,Password,CustomerCode,Address,RegisterDate,ZipCode,TelephoneNo,Gender,CustomerName,CustomerLevel,CustomerScore)
                    VALUES(1,'13298312275','abc123','','∫”ƒœ¬Â—Ù', getdate(),'450000','13298312275',0,'Amanda',13,95);
                ");

        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Customer");
        }
    }
}
