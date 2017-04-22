namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineDeliveryInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryInfo", "Index", c => c.Int(nullable: false));
            DropColumn("dbo.DeliveryInfo", "CurrentLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryInfo", "CurrentLocation", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.DeliveryInfo", "Index");
        }
    }
}
