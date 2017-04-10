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
                    values(1,'�����й����ӿƼ����޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(2,'ɽ��ɭ�ũ��װ�����޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(3,'֣�ݿ���Ȫ��ˮ�豸���޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(4,'�����غ�������Ϣ�Ƽ����޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(5,'�����˺��е������޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(6,'���ս�ӯ�Ҿ����޹�˾');

                    INSERT INTO Provider(Id,ProviderName)
                    values(7,'�ӱ�˶������װ�ι������޹�˾');
                 ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Provider");
        }
    }
}
