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
                    Values(9, N'�ֻ�������',1);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(10, N'���ԡ��칫',1);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(11, N'�Ҿӡ��Ҿߡ���װ������',3);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(12, N'Ьѥ�����',5);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(13, N'�ӱ�������Ʒ',5);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(14, N'��װ��Ůװ�����¡��鱦',2);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(15, N'�˶�������',6);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(16, N'ĸӤ���������',8);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(17, N'ʳƷ�����ࡢ���ʡ��ز�',4);

                    INSERT INTO Category(Id,CategoryName,ParentId)
                    Values(18, N'ͼ�顢����',7);
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}