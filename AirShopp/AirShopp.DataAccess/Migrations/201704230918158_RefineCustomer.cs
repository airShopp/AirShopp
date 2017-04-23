namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Address", c => c.String());
        }
    }
}
