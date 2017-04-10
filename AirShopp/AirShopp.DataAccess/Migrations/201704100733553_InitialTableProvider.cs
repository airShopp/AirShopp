namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTableProvider : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Provider ON
                    INSERT INTO Provider(Id,ProviderName)
                    values(1,'无锡市广恒电子科技有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(2,'山东森睿农牧装备有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(3,'郑州康宝泉净水设备有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(4,'金乡县韩鲜生信息科技有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(5,'沧州兴恒机械配件有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(6,'江苏江盈家居有限公司');

                    INSERT INTO Provider(Id,ProviderName)
                    values(7,'河北硕辰建筑装饰工程有限公司');
                 ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Provider");
        }
    }
}
