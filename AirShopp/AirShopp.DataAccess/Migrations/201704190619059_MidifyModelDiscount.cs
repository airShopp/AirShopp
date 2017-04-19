namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MidifyModelDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discount", "ProductId", c => c.Long(nullable: false));
            AddColumn("dbo.Discount", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discount", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discount", "IsUsed", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Discount", "ProductId");
            AddForeignKey("dbo.Discount", "ProductId", "dbo.Product", "Id");
            DropColumn("dbo.Discount", "CustomerLevel");
            DropColumn("dbo.Discount", "ScoreRequire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discount", "ScoreRequire", c => c.String());
            AddColumn("dbo.Discount", "CustomerLevel", c => c.String());
            DropForeignKey("dbo.Discount", "ProductId", "dbo.Product");
            DropIndex("dbo.Discount", new[] { "ProductId" });
            DropColumn("dbo.Discount", "IsUsed");
            DropColumn("dbo.Discount", "EndTime");
            DropColumn("dbo.Discount", "StartTime");
            DropColumn("dbo.Discount", "ProductId");
        }
    }
}
