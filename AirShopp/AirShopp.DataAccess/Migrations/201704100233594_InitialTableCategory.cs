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
                    Values(1,'���õ���');
                    INSERT INTO Category(Id,CategoryName)
                    Values(2,'����');
                    INSERT INTO Category(Id,CategoryName)
                    Values(3,'�Ҿ�');
                    INSERT INTO Category(Id,CategoryName)
                    Values(4,'ʳƷ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(5,'������ױ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(6,'����������Ʒ');
                    INSERT INTO Category(Id,CategoryName)
                    Values(7,'�ľ�ͼ��');
                    INSERT INTO Category(Id,CategoryName)
                    Values(8,'��Ů��ͯ��Ʒ');
                ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Category");
        }
    }
}
