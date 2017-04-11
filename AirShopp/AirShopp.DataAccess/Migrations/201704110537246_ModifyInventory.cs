namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInventory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Warehouse");
            AddColumn("dbo.Inventory", "WarehouseId", c => c.Long(nullable: false));
            CreateIndex("dbo.Inventory", "WarehouseId");
            AddForeignKey("dbo.Inventory", "WarehouseId", "dbo.Warehouse", "Id");
            DropColumn("dbo.Inventory", "FactoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "FactoryId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Inventory", "WarehouseId", "dbo.Warehouse");
            DropIndex("dbo.Inventory", new[] { "WarehouseId" });
            DropColumn("dbo.Inventory", "WarehouseId");
            AddForeignKey("dbo.Inventory", "ProductId", "dbo.Warehouse", "Id");
        }
    }
}
