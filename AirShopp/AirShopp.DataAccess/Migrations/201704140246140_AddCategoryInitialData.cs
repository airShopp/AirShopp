namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Category ON
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(1, N'家用电器',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(2, N'服饰',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(3, N'家居',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(4, N'食品',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(5, N'个护化妆',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(6, N'体育健身用品',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(7, N'文具图书',0);
                    家用电器
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
