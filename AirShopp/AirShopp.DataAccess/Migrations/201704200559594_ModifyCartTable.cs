namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCartTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cart", "ProductTotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cart", "ProductTotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
