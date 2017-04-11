namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "url");
        }
    }
}
