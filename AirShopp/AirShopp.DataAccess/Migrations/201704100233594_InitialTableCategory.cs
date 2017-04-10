namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTableCategory : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Category ON
                    INSERT INTO Category(Id,CategoryName)
                    Values(1,'家用电器');
                    INSERT INTO Category(Id,CategoryName)
                    Values(2,'服饰');
                    INSERT INTO Category(Id,CategoryName)
                    Values(3,'家居');
                    INSERT INTO Category(Id,CategoryName)
                    Values(4,'食品');
                    INSERT INTO Category(Id,CategoryName)
                    Values(5,'个护化妆');
                    INSERT INTO Category(Id,CategoryName)
                    Values(6,'体育健身用品');
                    INSERT INTO Category(Id,CategoryName)
                    Values(7,'文具图书');
                    INSERT INTO Category(Id,CategoryName)
                    Values(8,'妇女儿童用品');
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
