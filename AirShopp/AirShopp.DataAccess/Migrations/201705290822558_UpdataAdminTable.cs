namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataAdminTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(nullable: false, maxLength: 32));
            Sql(@"
                    UPDATE Admin
                    SET Password = '202CB962AC59075B964B07152D234B70'
                    WHERE Id = 1;
                ");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
