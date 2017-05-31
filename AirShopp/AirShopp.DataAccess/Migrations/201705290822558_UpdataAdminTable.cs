namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataAdminTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(nullable: false, maxLength: 32));
        }

        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
