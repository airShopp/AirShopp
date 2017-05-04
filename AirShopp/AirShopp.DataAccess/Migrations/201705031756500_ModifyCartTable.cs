namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCartTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "Id", "dbo.Customer");
            DropIndex("dbo.Cart", new[] { "Id" });
            AlterColumn("dbo.Cart", "CustomerId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "CustomerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Cart", "Id");
            AddForeignKey("dbo.Cart", "Id", "dbo.Customer", "Id");
        }
    }
}
