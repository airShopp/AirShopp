namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "url", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "url", c => c.Int(nullable: false));
        }
    }
}
