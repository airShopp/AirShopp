namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTableProductOutFactory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOutFactory", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductOutFactory", "CustomerId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOutFactory", "CustomerId");
            DropColumn("dbo.ProductOutFactory", "UnitPrice");
        }
    }
}
