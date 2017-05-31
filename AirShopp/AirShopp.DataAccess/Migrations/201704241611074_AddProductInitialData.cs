namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddProductInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT dbo.Product ON 
                    --����
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(1,'ԭװ���˳���� 5V1A�ֻ���Դ������ USB���ͷ5V0.7A�豸��Դ',1,1,GETUTCDATE(),'����',200,'/Content/img/product/���˳����.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(2,'С��M4 ����note3�ֻ�ԭװ��Ʒ��������߿�����������ֱ��ͷ2a',1,1,GETUTCDATE(),'����',200,'/Content/img/product/����������.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(3,'VIVO�����ԭװX6 X7 plus X9˫��������ͷV3max�ֻ�������Xplay5',1,1,GETUTCDATE(),'����',200,'/Content/img/product/Vivo�����.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(4,'��Ϊԭװ�������ҫ4C 3C 4A����4X 3X C8818 G610�ֻ������߳�ͷ',1,1,GETUTCDATE(),'����',200,'������',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(5,'8��USB���ٳ����ͷ�ֻ�ƽ��������ʾ��ڶ๦���ֻ�ͨ���Ų���2A',1,1,GETUTCDATE(),'����',200,'/Content/img/product/8��USB���ٳ����.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(6,'˴����Ʒ500W��ѹ��220Vת110V�ձ���������110Vת220V��ѹ��ѹ��',1,1,GETUTCDATE(),'����',200,'/Content/img/product/˴��500W��ѹ��.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(7,'���ǳ����ԭװ��ƷS6edge s7 note4/5�ֻ����ͷA8/9Vԭװ������',1,1,GETUTCDATE(),'����',200,'������',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(8,'��Ϊԭװ�����4X 5X��ҫ6 Plus Mate8 7 P8�������ֻ������ͨ��',1,1,GETUTCDATE(),'����',200,'/Content/img/product/��Ϊ���ͷ.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(9,'����ԭװ��������ͷ��ƷZ1 Z2 Z3 L36H C5 Z5 Z4 Z5P�ֻ�������',1,1,GETUTCDATE(),'����',200,'������',NULL,1);
                    --����
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(10,'����t��Ůװds�ݳ������¿��ɾ�ʿ���赸������¶�������˷�װ', 2, 8, GETUTCDATE(), '����', 300,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(11,'2017�ɹ�������ֱ���·�װ��Ůװ�����Ͼ�¶��С��ҹ���Ը�����ȹ', 2, 8, GETUTCDATE(), '����', 300,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(12,'2017�¿������ݷ�ɡ���ݳ�����������������װ�ŵ��赸��Ů', 2, 8, GETUTCDATE(), '����', 300,'/Content/img/product/�赸��.jpg','�����װ�������ʸ�˿����ѩ�Ĳ��Ͼ�����������  ���ϴ�������͸���Ժ�   ��ʽ��Լ������    �󷽶�������   �ʺ���������赸      ���ڹ�����ͬ��ͷ��    Ҳ������ϵ�ͷ���������ʽͷ��    һ�װ��� ��ƫԶ�������⣩',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(13,'��Χ120����Ůװ�ĺ�����MM���Գ������� ����T�� ���˷�װ������', 2, 8, GETUTCDATE(), '����', 300,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(14,'������ι����·������´���װС̩��Ȯè�䲩��������Ȯ���·�', 2, 8, GETUTCDATE(), '����', 300,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(15,'�Ƶ깤������װŮ ����������Ա��װ���� ������������Ա�Ʒ�', 2, 8, GETUTCDATE(), '����', 300,'/Content/img/product/��װ����.jpg','��������������������ֱ������������Χȹ���ڻ�ؼ�28Ԫ��Χȹ��������������Ϊֹ�����������ޣ�Ԥ�����١�����Ϊֹ��  Ůʿ����ƫС�����ǿ�����ѯ�ͷ�����',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(16,'���Ǽ�֤�������·�װ��Ů���䴿�ް׳�����֤�������¼������', 2, 8, GETUTCDATE(), '����', 300,'������','���Ǽ�֤�������·�װ��Ů�������ʰ׳�����֤�������¼������',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(17,'�����赸��Ů���������װ��̨�ݳ����������ر��ݷ�ˮ�䳤ȹ����', 2, 8, GETUTCDATE(), '����', 300,'������','�ף����ѡ�񣡶���ɫѡ�񣡲�Ҫ���Ŷ����������Ǹߵ��鶡���ϣ�����ϴ�ӡ�����ˮ������ɫ���������ʣ������г��Ϸ¶����ϣ����׳�˿��������Ʈ�����°ڱ�ȹ�屾��Ķ��ϻ��ᣡ����������Ʈ�Ķ��ϣ�������ȹ�ӵ�׹�У����������˸�����Ȼ�����������Ƿֱ����Ŷ��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(18,'���Ʒ��ΰµ�4S������б�Ž���Ů���������׳���ְҵװ�����Ʒ�', 2, 8, GETUTCDATE(), '����', 300,'������','�׹���ʱ������ճ����Ŷ���ɿ���Ʊ,���׷��Ĺ��� �ܹ���졣�ߴ粻���ʿ�������޸ĺ��˻���30�����Ͽ�֧�ֶ��ƣ�����LOGO��ȫ���������ߣ�0574-88355000',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(19,'������ �����װ��Ȯè�伪���޲�������̩�Ϲ����·����ļ�����', 2, 8, GETUTCDATE(), '����', 300,'������','�ܴ󷽵ľ������ƿ�ʽ~�����ٴ��Ŷ�����Ŀ��Ե���~�ﶬ�����������~Ҳ�����������䱳����~����ʵ��Ŷ��',1);
                    --ĸӤ
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(20,'���ڶ�����ۡ�����ÿ�ռ�� ���������� ��ͯ��Ů��ʳ20g*30��',8,9,GETUTCDATE(),'����',200,'������','һ��30���ײͣ�һ��һ�����ڻ�һ�£�����ÿ��Ӫ����',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(21,'Floradix Iron�¹�ҩ����Ԫ��ɫ��Ů��ͯ�в����ڷ�Һ500ml',8,9,GETUTCDATE(),'����',200,'/Content/img/product/�ڷ�Һ.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(22,'�������� ����/�����������&middot;����ʿ����������/������Ů��ͯ��',8,9,GETUTCDATE(),'����',200,'/Content/img/product/��.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(23,'��Ů���׶�԰�ֹ����ջ����������diy��ͯ�ֹ��������ϰ�',8,9,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(24,'������쵰��ë��ʵ�ø�Ů�������ͯ ��˾�����С��Ʒ����Ʒ',8,9,GETUTCDATE(),'����',200,'/Content/img/product/����ë��.jpg','����ë���ֹ��������ɰ������ͣ�����һ���ʺ�������ӭѡ������Ʒ����200����',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(25,'��Ů�������׶�԰�����ͯС��Ʒ����С��ƷС�����ֻ�������l',8,9,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                     VALUES(26,'���˸�Ů��DIY�ֹ��ؿ����ϰ� �ֻ�Ϳѻ��ֽ��ͯ������38����ʦ',8,9,GETUTCDATE(),'����',200,'������','�ڸ���ɫ˵���顣һ��6�ţ���ͯ������ֹ���',1);
 
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(27,'��Ůĸ�׽������ֹ�diyŦ�ۿ��ӻ����������ϰ� ��ͯ�������',8,9,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(28,'��Ůĸ�׽�EVA��ü��ֹ����껨���Զ�ͯ�׶�԰����diy�������ϰ�',8,9,GETUTCDATE(),'����',200,'������','',1);
                    --��ױƷ
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(29,'��ȸ����Ĥˮ�۾�������˯����Ĥ200g��ϴ��ˮ��ʪŮʿ����Ʒ��Ʒ',5,10,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(30,'�±�Ȫ��װר����Ʒ��Ч��ʪˮ�黯ױƷ�׺п��Ͳ�ˮ����Ʒ��װŮ',5,10,GETUTCDATE(),'����',200,'������','������ ��ˮ��ʪ���� ������ɫ',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(31,'��ͤ��ʿӪ�����¶100ml ��Һ��˪�������ײ�ˮ��ʪ����Ʒ��Ʒ',5,10,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(32,'������ʫ�����ʯ�񻤷�ƷС����װ��Ʒ���ױ�ʪ����ױ���а���',5,10,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(33,'����ˬ��ˮ��Һ����Һ��Ů��Ȳ�ˮ��ױ���ˮ��ʪ���׿��ͻ���Ʒ',5,10,GETUTCDATE(),'����',200,'������','ˮ �� ����Һ ����һ  ��2��1',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(34,'���������װȥ���������˪��Ʒ��Ů����ȥ�߲�ˮ��Ʒ��ױ����Ʒ',5,10,GETUTCDATE(),'����',200,'/Content/img/product/��ˮ��ױƷ.jpg','���������װ  �ú�30�� ��������˿�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(35,'��ת͸���ǿ�����ױƷ���ɺ�������ױ̨����Ʒ��������ܴ�ź���',5,10,GETUTCDATE(),'����',200,'������','��ױƷ���ɺУ�360����ת���������� ����Ʒ����ױ���ɣ�͸���ǿ������ʡ����̿��Ը��ݻ���Ʒ�߶ȵ��ڡ����ö๦����ױ̨ϴ��̨����������г�����������������Ƹ�֣���ƿ����ƿ������Ʒ����ױȫ����װ������������һĿ��Ȼ�������÷š�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(36,'ԡ�һ���Ʒ��Ż�ױƷ���ɺ��������ʽ��ױ̨�칫������������',5,10,GETUTCDATE(),'����',200,'������','��ˮ ���� ������ �๦��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(37,'����������װ��װ�轺1��ϴ����������ϴ����ױ����ˮ��ƿƷƿ',5,10,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(38,'���ʻ�ױ��װ��װϴ��ϴ���轺�������ð�������1��ˮ��ƿƷƿ',5,10,GETUTCDATE(),'����',200,'������','',1);
                    --�Ҿ�
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(39,'���� ��ƿ�ڼ������廨�Ҿ�װ��Ʒ�ɻ���ƿ��Լ�ִ��մɻ�ƿ',3,7,GETUTCDATE(),'����',200,'������','������⣬��Լ�ִ��մɻ�ƿ����ƿ����  ��װ�ٴ�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(40,'�����������ǽ��Ҿ���װ��Ʒŷʽǽ�ϹҼ���ͯ���Ҵ�ͷ���ι���',3,7,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(41,'ŷʽ�����������Ů���ڼ���Ů������贴����������Ҿ���Ʒ��Ʒ',3,7,GETUTCDATE(),'����',200,'������','�����Ļ��ߣ����������ͣ���������Ϊ���Ķ������ż�������װ�Ƿ���ˤ˫��Ӳֽ���װ����װ��ʵ�������ֻ����׿��Է������¹����˴λ��ʱ����Ŷ��������ʱ�Ǽ�Ŷ��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(42,'10˫����һ������Ь ��ɫɺ������Ь �ҾӴ�����Ь �ͷ������Ь',3,7,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(43,'�����й����ͭ���Ǯ����Ǯ�¹�Ǯ�Ҽ������вƹҼ��Ҿӷ�ˮ��Ʒ',3,7,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(44,'���հ״ɸɻ������ǻ�ƿ��Լ�ִ���ɫ�廨�Ҿӿ����մɰڼ�С����',3,7,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(45,'���ļ��Ҿ��ļ���Ů��������������Ь�Ӽ�����ľ�ذ���׷�������',3,7,GETUTCDATE(),'����',200,'/Content/img/product/������.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(46,'�������ؼۡ��в���ײ˰ڼ���Ͳ�ҾӰ칫��������Ʒ���⿪ҵ��Ʒ',3,7,GETUTCDATE(),'����',200,'������','�ײ˱�Ͳ���������£�ʵ�ã������ѣ��ͳ���������ʦ�����ϰ���ѡ���ٷֱ�ʵ�ľ�����ps��ȫ�����ʣ�����',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(47,'����ЬŮ�������°�����Ҿ����ڷ�����ů��׶����ͯë��Ь��ʿ',3,7,GETUTCDATE(),'����',200,'������','��Լ�Ҿ�  ������ů  ����ֱ��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(48,'�����ؼ۾Ӽ���ЬŮ�ĵذ�����������Ь�мҾ�����Ь �ļ�����Ь',3,7,GETUTCDATE(),'����',200,'������','',1);
                    --����
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(49,'�ļ��ᱡ͸���˶������ٸ�t�������οս����ܲ��٤ѵ����������',6,5,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(50,'�Ћq���ļ��¿��٤������������������ѩ���赸�½����Ůɴ��',6,5,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(51,'��̬��ʦ �٤���ɫ��Ů��������ӳ��Ӻ�TPE������ζ�˶������',6,5,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(52,'�ؼۿ�������2/4/8/10/12LB���ý�������6����ɫ������ʿŮʿ�ݱ�',6,5,GETUTCDATE(),'����',200,'������','�����彭�㻦���հ��ʣ��㶫�����������Ϻ������Ϻӱ��������3Ԫһֻ�ʷѡ�������ʡ�����Ϲ����Ĵ�����ɽ�����������ʷ�15Ԫһֻ���������������ʣ����������ʷѡ�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(53,'˫�ֱ�����40kg30��������������ѵ���������ı�����60����50����',6,5,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(54,'INSANITY�ӳ��ӿ��������������ٵ�����˶����٤��T25/KEEP',6,5,GETUTCDATE(),'����',200,'������','ר��Ϊ��ǿ�ȵĽ���ѵ����INSANITY/T25/����Ȼ/��������ǿʽѵ������Ƶġ�����л�����г�ǿ���������Ľ��������ϥ�ǡ��󱳺��׹ؽ��𵽵ı������á����еļ�ͥ���ڽ�������û��������л����һ�������֧�֣������Щ���ǵĽ������Ƴ�����198cm��94cm ���6mm �����°����ٵ�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(55,'ҽ�ùؽڱ�ů���⻤���˶�������͸�����ļ���Ů������ë������',6,5,GETUTCDATE(),'����',200,'������','1���Ű���������ɴ�������ɳڣ���㡢�����ص��Ժá� 2��һ������޷�֯�칤�ա����幤ѧ��ƣ������ؽںͼ���ṹ�����������������������⣬��֧�����á� 3��ѭ���ѹ��ƣ������ؽڲ�λ�� 4��͸���Ժ���ʪ�ԡ�',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(56,'��mm�����٤��Ů��װ���ļ������ܲ��˶�������������ٸ�����',6,5,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(57,'�٤�潡���ӳ��ӿ�80��ѧ�߷����٤̺�Ӻ��˶�����������Ʒ',6,5,GETUTCDATE(),'����',200,'������','185cmX80cm���Ӻ�10mm��������ɫ��ѡ �˶�ר�õ档 ����Ʒ�ʡ��������ʡ���ζ��������������������',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(58,'�٤��Ӻ�15mm�ӳ��ӿ�80cm������ӷ�����ζ�٤̺΢覴�Ʒ�ؼ�',6,5,GETUTCDATE(),'����',200,'������','�ӳ�185cm   �ӿ�90cm   �Ӻ�15mm  ���ܶȸ߻ص�   �Լ۱ȳ���',1);
                    --ʳƷ
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(59,'�»���ʿС��ɽ����ζ/֥��/����ζ��ʳƷһ��������4�����2kg',4,11,GETUTCDATE(),'����',200,'������','ɽ������ԭζ����Ͽ�ζ���ۺϿ�ζ �����������ζ��װ    ����4����ʡ�ƫԶ�������⡿�������ζ���ڶ�����ע��Ĭ�������  ��ѡ��ζ��֥�顢����������',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(60,'����ţ����25g*40��������ζ��ʳƷ����С�Զ�ʱ������ʳ�����',4,11,GETUTCDATE(),'����',200,'������','Сʱ���ζ����������ʳ!20�� ��40�� ���ֹ���ѡ',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(61,'�������ɱ�ľ�Ǵ��������������ʳƷ�����˲�����ʳ�и���㵰��',4,11,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(62,'�Ϻü���ϺƬ��ƬС������ʳƷ��óԵĵ������������Ů�����',4,11,GETUTCDATE(),'����',200,'������','�¾ɰ�װ�����',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(63,'���������ز���ʳ��������ԭζ�����ز���ʳͯ�껳��ʳƷ500g����',4,11,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(64,'���ǽ����ϲ�ǹ��ò�ͷС��Q��QQ����ɢװ500g85����ʳƷ����',4,11,GETUTCDATE(),'����',200,'/Content/img/product/QQ����.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(65,'������ ������ζ����������ը��ͨ����ʳƷ��� 56g*20������',4,11,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(66,'���մ�Ǵ���ζ���Ǵ��������������Ǻ����ز��칫�������ʳƷ',4,11,GETUTCDATE(),'����',200,'������','�þ��պ�װ���Ǵ��������ζ����1������ζ��ԭ����ζ��2������ζ��΢��΢��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(67,'�������Ͼ���Ѽ26g*40���칫��С����ʳƷ����80���ͯ������ʳ',4,11,GETUTCDATE(),'����',200,'������','���26g*40��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(68,'�׶��濾��Ƭ����2kg�����ʳƷ���濾����Ƭ���ɴ�����ͷƬ2000g',4,11,GETUTCDATE(),'����',200,'������','��Ʒ�Ƕ���С��װ��һ��3Ƭװ60��Լ4� һ��6Ƭװ30��Լ4��ǰ��������µ����ӷ����ġ���ָ����ζ�� ��Ʒ��������Ʒ�����������Լ���ֽ���װ�ģ� ��������������ˤ��ѹ ������û�취��֤ �����飬��������� �������� ����֮��������£�',1);
                    --�ľ�ͼ��
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(69,'�������Z�ɰ�ͼ���Ķ���¼�� �������ժ�Ǳ� ѧ���ʼǱ����ľ�',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(70,'ѧ������������ܼ������������鼮�ľ����ɼ������С�Ͱ칫���',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(71,'�칫С�д������ѧ�����������鿿ͼ��ݵ����Ķ��������ľ�',7,12,GETUTCDATE(),'����',200,'������','�˼۸�Ϊ1�Եļ۸������۸���ۣ��칫ѧ��ѧУ��ͼ�����������',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(72,'�����ľ� ѧ��ר�ö���ʼǱ� �����鼮��¼�� �������� �� 16K',7,12,GETUTCDATE(),'����',200,'������','�������ó���װ������̯ƽ������ҳ�� ��ҳ����80g��дֽ����ɫֽ�ţ���ɫ����ӡˢ�� רҵ��Ƶ��ʺ϶�����رʼǵı�������һ��ȫ���ߵĸ����ã� һ���ɼ�39����������µ���رʼǣ�����ϵ�п�ѡ�����ҳ����һ�����Ƿ��治ͬ��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(73,'�ؼ����ϼа칫�ľ�ʵľ�ż����ɹ����鼮��־������ �ļ��� ����',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(74,'ľ�ʻ������ľ��ͼ��չʾ�ܻ汾����չʾ��רҵ�ľ�չ���ͯ���',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(75,'��ͯ����Ϳɫ���׶������������� ����ѧϰ�滭�����鼮�ľ���Ʒ',7,12,GETUTCDATE(),'����',200,'������','ÿһ������Ϳɫ���裬�ο�ͼ�Լ��滭��ʾ���������ʡ�ˮ�ʱʡ���Ǧ�����ϵ�Ϳɫ��',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(76,'�ⶩ����ǽ��ճ����������ɼ����Ҵ�ͷ���ľ��鼮�ֻ�ճǽ�ڹҼ�',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(77,'�����ľߵ�����׻����״�������� ����ͼ�鹤�� ��֯�������',7,12,GETUTCDATE(),'����',200,'������','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(78,'����ѧ���ľ߿������������鼮����ʽ��Ҵ��������ɺ����ɹҴ�',7,12,GETUTCDATE(),'����',200,'������','˫�����ˮ�������ʴ���9���+2С�񣬿�����40���飬����50kg������ţ��������ѧϰ�������ɺð��֣������ϵ�������',1);
                    ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Product");
        }
    }
}
