namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliveryStationInitialData : DbMigration
    {
        public override void Up()
        {
             Sql(@"
                   SET IDENTITY_INSERT DeliveryStation ON
                       
                ");
        }
        
        public override void Down()
        {
            Sql(@"
                    TRUNCATE TABLE DeliveryStation
               ");
        }
    }
}
