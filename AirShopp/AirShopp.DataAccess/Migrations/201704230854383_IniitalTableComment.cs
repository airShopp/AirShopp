namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniitalTableComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "Comments", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "Comments", c => c.String());
        }
    }
}
