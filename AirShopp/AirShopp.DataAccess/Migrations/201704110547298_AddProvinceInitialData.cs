namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddProvinceInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   SET IDENTITY_INSERT Province ON
                   INSERT  Province(Id,ProvinceId,ProvinceName)
                       SELECT 1,110000,'������' UNION
                       SELECT 2,120000,'�����' UNION
                       SELECT 3,130000,'�ӱ�ʡ' UNION
                       SELECT 4,140000,'ɽ��ʡ' UNION
                       SELECT 5,150000,'���ɹ�������'UNION
                       SELECT 6,210000,'����ʡ' UNION
                       SELECT 7,220000,'����ʡ' UNION
                       SELECT 8,230000,'������ʡ' UNION
                       SELECT 9,310000,'�Ϻ���' UNION
                       SELECT 10,320000,'����ʡ' UNION
                       SELECT 11,330000,'�㽭ʡ' UNION
                       SELECT 12,340000,'����ʡ' UNION
                       SELECT 13,350000,'����ʡ' UNION
                       SELECT 14,360000,'����ʡ' UNION
                       SELECT 15,370000,'ɽ��ʡ' UNION
                       SELECT 16,410000,'����ʡ' UNION
                       SELECT 17,420000,'����ʡ' UNION
                       SELECT 18,430000,'����ʡ' UNION
                       SELECT 19,440000,'�㶫ʡ' UNION
                       SELECT 20,450000,'����׳��������' UNION
                       SELECT 21,460000,'����ʡ' UNION
                       SELECT 22,500000,'������' UNION
                       SELECT 23,510000,'�Ĵ�ʡ' UNION
                       SELECT 24,520000,'����ʡ' UNION
                       SELECT 25,530000,'����ʡ' UNION
                       SELECT 26,540000,'����������' UNION
                       SELECT 27,610000,'����ʡ' UNION
                       SELECT 28,620000,'����ʡ' UNION
                       SELECT 29,630000,'�ຣʡ' UNION
                       SELECT 30,640000,'���Ļ���������' UNION
                       SELECT 31,650000,'�½�ά���������' UNION
                       SELECT 32,710000,'̨��ʡ' UNION
                       SELECT 33,810000,'����ر�������' UNION
                       SELECT 34,820000,'�����ر�������'
                ");
        }

        public override void Down()
        {
            Sql(@"
                    TRUNCATE TABLE Province
               ");
        }
    }
}
