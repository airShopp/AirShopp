namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineProductOnSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IsOnSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsOnSale");
        }
    }
}
