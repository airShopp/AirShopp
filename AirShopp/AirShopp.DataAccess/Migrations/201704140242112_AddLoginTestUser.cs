namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddLoginTestUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   SET IDENTITY_INSERT Admin ON
                   INSERT INTO dbo.Admin(Id,Account,Password)
                   VALUES(1,'Amanda','123');
                   INSERT INTO dbo.Admin(Id,Account,Password)
                   VALUES(2,'Japser','123');
                   INSERT INTO dbo.Admin(Id,Account,Password)
                   VALUES(3,'Kenneth','123');
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Admin");
        }
    }
}
