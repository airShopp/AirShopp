namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdressAndComment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inventory", "FactoryId");
            RenameIndex(table: "dbo.Inventory", name: "IX_ProductId", newName: "IX_FactoryId");
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        DeliveryAddress = c.String(),
                        ReceiverName = c.String(),
                        ReceiverPhone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Order", "AddressId", c => c.Long(nullable: false));
            AddColumn("dbo.Order", "IsSpecialOrder", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "SpecialType", c => c.String());
            CreateIndex("dbo.Order", "AddressId");
            CreateIndex("dbo.Inventory", "ProductId");
            AddForeignKey("dbo.Order", "AddressId", "dbo.Address", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Comment", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Inventory", new[] { "ProductId" });
            DropIndex("dbo.Comment", new[] { "ProductId" });
            DropIndex("dbo.Comment", new[] { "OrderId" });
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropColumn("dbo.Order", "SpecialType");
            DropColumn("dbo.Order", "IsSpecialOrder");
            DropColumn("dbo.Order", "AddressId");
            DropTable("dbo.Comment");
            DropTable("dbo.Address");
            RenameIndex(table: "dbo.Inventory", name: "IX_FactoryId", newName: "IX_ProductId");
            RenameColumn(table: "dbo.Inventory", name: "FactoryId", newName: "ProductId");
            AddColumn("dbo.Inventory", "FactoryId", c => c.Long(nullable: false));
        }
    }
}
