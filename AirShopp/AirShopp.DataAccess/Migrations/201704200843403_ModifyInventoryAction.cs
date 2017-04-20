namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInventoryAction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryAction", "ProductInFactoryId", "dbo.ProductInFactory");
            DropForeignKey("dbo.InventoryAction", "ProductOutFactoryId", "dbo.ProductOutFactory");
            DropIndex("dbo.InventoryAction", new[] { "ProductInFactoryId" });
            DropIndex("dbo.InventoryAction", new[] { "ProductOutFactoryId" });
            AlterColumn("dbo.InventoryAction", "ProductInFactoryId", c => c.Long());
            AlterColumn("dbo.InventoryAction", "ProductOutFactoryId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryAction", "ProductOutFactoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.InventoryAction", "ProductInFactoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.InventoryAction", "ProductOutFactoryId");
            CreateIndex("dbo.InventoryAction", "ProductInFactoryId");
            AddForeignKey("dbo.InventoryAction", "ProductOutFactoryId", "dbo.ProductOutFactory", "Id");
            AddForeignKey("dbo.InventoryAction", "ProductInFactoryId", "dbo.ProductInFactory", "Id");
        }
    }
}
