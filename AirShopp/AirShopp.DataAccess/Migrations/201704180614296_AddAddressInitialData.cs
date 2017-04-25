namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT[dbo].[Address] ON
                    INSERT INTO[Address](Id,CustomerId,AreaId,DeliveryAddress,ReceiverName,ReceiverPhone)
                    VALUES(1,1,1,'河南省洛阳市','Amanda','13298312275');
                ");

        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Address");
        }
    }
}
