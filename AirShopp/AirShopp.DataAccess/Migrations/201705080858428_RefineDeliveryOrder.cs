namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineDeliveryOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliveryNote", "Id", "dbo.Order");
            DropForeignKey("dbo.DeliveryOrder", "Id", "dbo.Order");
            DropIndex("dbo.DeliveryNote", new[] { "Id" });
            DropIndex("dbo.DeliveryOrder", new[] { "Id" });
            DropColumn("dbo.DeliveryNote", "BarCodeImgURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryNote", "BarCodeImgURL", c => c.String(nullable: false, maxLength: 512));
            CreateIndex("dbo.DeliveryOrder", "Id");
            CreateIndex("dbo.DeliveryNote", "Id");
            AddForeignKey("dbo.DeliveryOrder", "Id", "dbo.Order", "Id");
            AddForeignKey("dbo.DeliveryNote", "Id", "dbo.Order", "Id");
        }
    }
}
