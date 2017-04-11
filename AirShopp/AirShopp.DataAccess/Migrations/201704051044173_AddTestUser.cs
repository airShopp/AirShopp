namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   SET IDENTITY_INSERT Admin ON
                   INSERT INTO dbo.Admin(Id,Account,Password)
                   VALUES(1,'zhangsan','123');
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Admin");
        }
    }
}
