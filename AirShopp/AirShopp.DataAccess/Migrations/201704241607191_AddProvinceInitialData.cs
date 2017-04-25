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
                       SELECT 1,110000,N'������' UNION
                       SELECT 2,120000,N'�����' UNION
                       SELECT 3,130000,N'�ӱ�ʡ' UNION
                       SELECT 4,140000,N'ɽ��ʡ' UNION
                       SELECT 5,150000,N'���ɹ�������'UNION
                       SELECT 6,210000,N'����ʡ' UNION
                       SELECT 7,220000,N'����ʡ' UNION
                       SELECT 8,230000,N'������ʡ' UNION
                       SELECT 9,310000,N'�Ϻ���' UNION
                       SELECT 10,320000,N'����ʡ' UNION
                       SELECT 11,330000,N'�㽭ʡ' UNION
                       SELECT 12,340000,N'����ʡ' UNION
                       SELECT 13,350000,N'����ʡ' UNION
                       SELECT 14,360000,N'����ʡ' UNION
                       SELECT 15,370000,N'ɽ��ʡ' UNION
                       SELECT 16,410000,N'����ʡ' UNION
                       SELECT 17,420000,N'����ʡ' UNION
                       SELECT 18,430000,N'����ʡ' UNION
                       SELECT 19,440000,N'�㶫ʡ' UNION
                       SELECT 20,450000,N'����׳��������' UNION
                       SELECT 21,460000,N'����ʡ' UNION
                       SELECT 22,500000,N'������' UNION
                       SELECT 23,510000,N'�Ĵ�ʡ' UNION
                       SELECT 24,520000,N'����ʡ' UNION
                       SELECT 25,530000,N'����ʡ' UNION
                       SELECT 26,540000,N'����������' UNION
                       SELECT 27,610000,N'����ʡ' UNION
                       SELECT 28,620000,N'����ʡ' UNION
                       SELECT 29,630000,N'�ຣʡ' UNION
                       SELECT 30,640000,N'���Ļ���������' UNION
                       SELECT 31,650000,N'�½�ά���������' UNION
                       SELECT 32,710000,N'̨��ʡ' UNION
                       SELECT 33,810000,N'����ر�������' UNION
                       SELECT 34,820000,N'�����ر�������'
                ");
        }

        public override void Down()
        {
            Sql(@"
                    DELETE FROM  dbo.Province
               ");
        }
    }
}