namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyReturnModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Return", "Id", "dbo.OrderItem");
            DropIndex("dbo.Return", new[] { "Id" });
            AddColumn("dbo.OrderItem", "Return_Id", c => c.Long());
            CreateIndex("dbo.OrderItem", "Return_Id");
            AddForeignKey("dbo.OrderItem", "Return_Id", "dbo.Return", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Return_Id", "dbo.Return");
            DropIndex("dbo.OrderItem", new[] { "Return_Id" });
            DropColumn("dbo.OrderItem", "Return_Id");
            CreateIndex("dbo.Return", "Id");
            AddForeignKey("dbo.Return", "Id", "dbo.OrderItem", "Id");
        }
    }
}
