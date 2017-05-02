namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartItemMapping : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartItem", "ItemStatus", c => c.String(nullable: false, maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CartItem", "ItemStatus", c => c.String());
        }
    }
}
