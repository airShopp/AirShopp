namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressAndComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        ReceiverName = c.String(nullable: false),
                        ReceiverPhone = c.String(nullable: false),
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
            AddForeignKey("dbo.Order", "AddressId", "dbo.Address", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Comment", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Comment", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropIndex("dbo.Comment", new[] { "ProductId" });
            DropIndex("dbo.Comment", new[] { "OrderId" });
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropColumn("dbo.Order", "SpecialType");
            DropColumn("dbo.Order", "IsSpecialOrder");
            DropColumn("dbo.Order", "AddressId");
            DropTable("dbo.Comment");
            DropTable("dbo.Address");
        }
    }
}
