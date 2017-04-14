namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProductAddColumnDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Description");
        }
    }
}
