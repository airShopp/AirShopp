namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryAction", "InventoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.InventoryAction", "InventoryId");
            AddForeignKey("dbo.InventoryAction", "InventoryId", "dbo.Inventory", "Id");
            DropColumn("dbo.ProductInFactory", "ProductName");
            DropColumn("dbo.ProductOutFactory", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOutFactory", "ProductName", c => c.String());
            AddColumn("dbo.ProductInFactory", "ProductName", c => c.String());
            DropForeignKey("dbo.InventoryAction", "InventoryId", "dbo.Inventory");
            DropIndex("dbo.InventoryAction", new[] { "InventoryId" });
            DropColumn("dbo.InventoryAction", "InventoryId");
        }
    }
}
