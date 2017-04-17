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
                    Values(1, N'���õ���',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(2, N'����',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(3, N'�Ҿ�',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(4, N'ʳƷ',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(5, N'������ױ',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(6, N'����������Ʒ',0);
                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(7, N'�ľ�ͼ��',0);
                    ���õ���
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
