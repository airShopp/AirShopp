namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "ParentId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "ParentId");
        }
    }
}
