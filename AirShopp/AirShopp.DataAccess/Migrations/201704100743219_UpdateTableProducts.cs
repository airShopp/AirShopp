namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProducts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "Supply");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Supply", c => c.Int(nullable: false));
        }
    }
}
