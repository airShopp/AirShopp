namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT dbo.Category ON
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(9, N'手机、数码',1);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(10, N'电脑、办公',1);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(11, N'家居、家具、家装、厨具',3);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(12, N'鞋靴、箱包',5);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(13, N'钟表、奢饰品',5);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(14, N'男装、女装、内衣、珠宝',2);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(15, N'运动、户外',6);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(16, N'母婴、玩具乐器',8);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(17, N'食品、酒类、生鲜、特产',4);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(18, N'图书、音像',7);
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
