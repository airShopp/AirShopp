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
                    INSERT INTO Category(Id,CategoryName)
                    Values(1, N'���õ���');
                    INSERT INTO Category(Id,CategoryName)
                    Values(2, N'����');
                    INSERT INTO Category(Id,CategoryName)
                    Values(3, N'�Ҿ�');
                    INSERT INTO Category(Id,CategoryName)
                    Values(4, N'ʳƷ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(5, N'������ױ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(6, N'����������Ʒ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(7, N'�ľ�ͼ��');
                    INSERT INTO Category(Id,CategoryName)
                    Values(8, N'��Ů��ͯ��Ʒ');
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
