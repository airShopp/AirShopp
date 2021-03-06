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
                       SELECT 1,110000,N'北京市' UNION
                       SELECT 2,120000,N'天津市' UNION
                       SELECT 3,130000,N'河北省' UNION
                       SELECT 4,140000,N'山西省' UNION
                       SELECT 5,150000,N'内蒙古自治区'UNION
                       SELECT 6,210000,N'辽宁省' UNION
                       SELECT 7,220000,N'吉林省' UNION
                       SELECT 8,230000,N'黑龙江省' UNION
                       SELECT 9,310000,N'上海市' UNION
                       SELECT 10,320000,N'江苏省' UNION
                       SELECT 11,330000,N'浙江省' UNION
                       SELECT 12,340000,N'安徽省' UNION
                       SELECT 13,350000,N'福建省' UNION
                       SELECT 14,360000,N'江西省' UNION
                       SELECT 15,370000,N'山东省' UNION
                       SELECT 16,410000,N'河南省' UNION
                       SELECT 17,420000,N'湖北省' UNION
                       SELECT 18,430000,N'湖南省' UNION
                       SELECT 19,440000,N'广东省' UNION
                       SELECT 20,450000,N'广西壮族自治区' UNION
                       SELECT 21,460000,N'海南省' UNION
                       SELECT 22,500000,N'重庆市' UNION
                       SELECT 23,510000,N'四川省' UNION
                       SELECT 24,520000,N'贵州省' UNION
                       SELECT 25,530000,N'云南省' UNION
                       SELECT 26,540000,N'西藏自治区' UNION
                       SELECT 27,610000,N'陕西省' UNION
                       SELECT 28,620000,N'甘肃省' UNION
                       SELECT 29,630000,N'青海省' UNION
                       SELECT 30,640000,N'宁夏回族自治区' UNION
                       SELECT 31,650000,N'新疆维吾尔自治区' UNION
                       SELECT 32,710000,N'台湾省' UNION
                       SELECT 33,810000,N'香港特别行政区' UNION
                       SELECT 34,820000,N'澳门特别行政区'
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