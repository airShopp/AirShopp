namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAddressInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Address] ON 
                    INSERT [dbo].[Address] ([Id], [ReceiverName], [ReceiverPhone], [DeliveryAddress], [IsDefault], [Latitude], [Longitude], [CustomerId], [AreaId])
                    VALUES (1, N'Kenneth', N'13298312302', N'�Ϻ����ֶ�����ʤ��·188��', 1, 31.249784, 121.695932, 1, 795)
                    INSERT [dbo].[Address] ([Id], [ReceiverName], [ReceiverPhone], [DeliveryAddress], [IsDefault], [Latitude], [Longitude], [CustomerId], [AreaId])
                    VALUES (2, N'Jasper', N'13298312307', N'�Ϻ���¬����̩��·210Ū', 1, 31.213884, 121.475845, 2, 784)
                    INSERT [dbo].[Address] ([Id], [ReceiverName], [ReceiverPhone], [DeliveryAddress], [IsDefault], [Latitude], [Longitude], [CustomerId], [AreaId])
                    VALUES (3, N'Amanda', N'13298312275', N'�Ϻ����ֶ�������̩�㳡', 1, 31.211998, 121.608481, 3, 795)
                ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Address");
        }
    }
}
