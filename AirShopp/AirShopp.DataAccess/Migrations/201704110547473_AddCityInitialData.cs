namespace AirShopp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddCityInitialData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   SET IDENTITY_INSERT City ON
                   INSERT  City (ID,CityId,CityName,ProvinceId) 
                       SELECT 1,110100,'��Ͻ��',110000 UNION
                       SELECT 2,110200,'��',110000 UNION
                       SELECT 3,120100,'��Ͻ��',120000 UNION
                       SELECT 4,120200,'��',120000 UNION
                       SELECT 5,130100,'ʯ��ׯ��',130000 UNION
                       SELECT 6,130200,'��ɽ��',130000 UNION
                       SELECT 7,130300,'�ػʵ���',130000 UNION
                       SELECT 8,130400,'������',130000 UNION
                       SELECT 9,130500,'��̨��',130000 UNION
                       SELECT 10,130600,'������',130000 UNION
                       SELECT 11,130700,'�żҿ���',130000 UNION
                       SELECT 12,130800,'�е���',130000 UNION
                       SELECT 13,130900,'������',130000 UNION
                       SELECT 14,131000,'�ȷ���',130000 UNION
                       SELECT 15,131100,'��ˮ��',130000 UNION
                       SELECT 16,140100,'̫ԭ��',140000 UNION
                       SELECT 17,140200,'��ͬ��',140000 UNION
                       SELECT 18,140300,'��Ȫ��',140000 UNION
                       SELECT 19,140400,'������',140000 UNION
                       SELECT 20,140500,'������',140000 UNION
                       SELECT 21,140600,'˷����',140000 UNION
                       SELECT 22,140700,'������',140000 UNION
                       SELECT 23,140800,'�˳���',140000 UNION
                       SELECT 24,140900,'������',140000 UNION
                       SELECT 25,141000,'�ٷ���',140000 UNION
                       SELECT 26,141100,'������',140000

                       INSERT  City (ID,CityId,CityName,ProvinceId) 
                       SELECT 27,150100,'���ͺ�����',150000 UNION
                       SELECT 28,150200,'��ͷ��',150000 UNION
                       SELECT 29,150300,'�ں���',150000 UNION
                       SELECT 30,150400,'�����',150000 UNION
                       SELECT 31,150500,'ͨ����',150000 UNION
                       SELECT 32,150600,'������˹��',150000 UNION
                       SELECT 33,150700,'���ױ�����',150000 UNION
                       SELECT 34,150800,'�����׶���',150000 UNION
                       SELECT 35,150900,'�����첼��',150000 UNION
                       SELECT 36,152200,'�˰���',150000 UNION
                       SELECT 37,152500,'���ֹ�����',150000 UNION
                       SELECT 38,152900,'��������',150000 UNION
                       SELECT 39,210100,'������',210000 UNION
                       SELECT 40,210200,'������',210000 UNION
                       SELECT 41,210300,'��ɽ��',210000 UNION
                       SELECT 42,210400,'��˳��',210000 UNION
                       SELECT 43,210500,'��Ϫ��',210000 UNION
                       SELECT 44,210600,'������',210000 UNION
                       SELECT 45,210700,'������',210000 UNION
                       SELECT 46,210800,'Ӫ����',210000 UNION
                       SELECT 47,210900,'������',210000 UNION
                       SELECT 48,211000,'������',210000 UNION
                       SELECT 49,211100,'�̽���',210000 UNION
                       SELECT 50,211200,'������',210000 UNION
                       SELECT 51,211300,'������',210000 UNION
                       SELECT 52,211400,'��«����',210000 UNION
                       SELECT 53,220100,'������',220000 UNION
                       SELECT 54,220200,'������',220000 UNION
                       SELECT 55,220300,'��ƽ��',220000 UNION
                       SELECT 56,220400,'��Դ��',220000 UNION
                       SELECT 57,220500,'ͨ����',220000 UNION
                       SELECT 58,220600,'��ɽ��',220000 UNION
                       SELECT 59,220700,'��ԭ��',220000 UNION
                       SELECT 60,220800,'�׳���',220000 UNION
                       SELECT 61,222400,'�ӱ߳�����������',220000 UNION
                       SELECT 62,230100,'��������',230000 UNION
                       SELECT 63,230200,'���������',230000 UNION
                       SELECT 64,230300,'������',230000 UNION
                       SELECT 65,230400,'�׸���',230000 UNION
                       SELECT 66,230500,'˫Ѽɽ��',230000 UNION
                       SELECT 67,230600,'������',230000 UNION
                       SELECT 68,230700,'������',230000 UNION
                       SELECT 69,230800,'��ľ˹��',230000 UNION
                       SELECT 70,230900,'��̨����',230000 UNION
                       SELECT 71,231000,'ĵ������',230000 UNION
                       SELECT 72,231100,'�ں���',230000 UNION
                       SELECT 73,231200,'�绯��',230000 UNION
                       SELECT 74,232700,'���˰������',230000 UNION
                       SELECT 75,310100,'��Ͻ��',310000 UNION
                       SELECT 76,310200,'��',310000 UNION
                       SELECT 77,320100,'�Ͼ���',320000 UNION
                       SELECT 78,320200,'������',320000 UNION
                       SELECT 79,320300,'������',320000 UNION
                       SELECT 80,320400,'������',320000 UNION
                       SELECT 81,320500,'������',320000 UNION
                       SELECT 82,320600,'��ͨ��',320000 UNION
                       SELECT 83,320700,'���Ƹ���',320000 UNION
                       SELECT 84,320800,'������',320000 UNION
                       SELECT 85,320900,'�γ���',320000 UNION
                       SELECT 86,321000,'������',320000 UNION
                       SELECT 87,321100,'����',320000 UNION
                       SELECT 88,321200,'̩����',320000 UNION
                       SELECT 89,321300,'��Ǩ��',320000 UNION
                       SELECT 90,330100,'������',330000 UNION
                       SELECT 91,330200,'������',330000 UNION
                       SELECT 92,330300,'������',330000 UNION
                       SELECT 93,330400,'������',330000 UNION
                       SELECT 94,330500,'������',330000 UNION
                       SELECT 95,330600,'������',330000 UNION
                       SELECT 96,330700,'����',330000 UNION
                       SELECT 97,330800,'������',330000 UNION
                       SELECT 98,330900,'��ɽ��',330000 UNION
                       SELECT 99,331000,'̨����',330000 UNION
                       SELECT 100,331100,'��ˮ��',330000 UNION
                       SELECT 101,340100,'�Ϸ���',340000 UNION
                       SELECT 102,340200,'�ߺ���',340000 UNION
                       SELECT 103,340300,'������',340000 UNION
                       SELECT 104,340400,'������',340000 UNION
                       SELECT 105,340500,'��ɽ��',340000 UNION
                       SELECT 106,340600,'������',340000 UNION
                       SELECT 107,340700,'ͭ����',340000 UNION
                       SELECT 108,340800,'������',340000 UNION
                       SELECT 109,341000,'��ɽ��',340000 UNION
                       SELECT 110,341100,'������',340000 UNION
                       SELECT 111,341200,'������',340000 UNION
                       SELECT 112,341300,'������',340000 UNION
                       SELECT 113,341400,'������',340000 UNION
                       SELECT 114,341500,'������',340000 UNION
                       SELECT 115,341600,'������',340000 UNION
                       SELECT 116,341700,'������',340000 UNION
                       SELECT 117,341800,'������',340000 UNION
                       SELECT 118,350100,'������',350000 UNION
                       SELECT 119,350200,'������',350000 UNION
                       SELECT 120,350300,'������',350000 UNION
                       SELECT 121,350400,'������',350000 UNION
                       SELECT 122,350500,'Ȫ����',350000 UNION
                       SELECT 123,350600,'������',350000 UNION
                       SELECT 124,350700,'��ƽ��',350000 UNION
                       SELECT 125,350800,'������',350000 UNION
                       SELECT 126,350900,'������',350000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 127,360100,'�ϲ���',360000 UNION
                       SELECT 128,360200,'��������',360000 UNION
                       SELECT 129,360300,'Ƽ����',360000 UNION
                       SELECT 130,360400,'�Ž���',360000 UNION
                       SELECT 131,360500,'������',360000 UNION
                       SELECT 132,360600,'ӥ̶��',360000 UNION
                       SELECT 133,360700,'������',360000 UNION
                       SELECT 134,360800,'������',360000 UNION
                       SELECT 135,360900,'�˴���',360000 UNION
                       SELECT 136,361000,'������',360000 UNION
                       SELECT 137,361100,'������',360000 UNION
                       SELECT 138,370100,'������',370000 UNION
                       SELECT 139,370200,'�ൺ��',370000 UNION
                       SELECT 140,370300,'�Ͳ���',370000 UNION
                       SELECT 141,370400,'��ׯ��',370000 UNION
                       SELECT 142,370500,'��Ӫ��',370000 UNION
                       SELECT 143,370600,'��̨��',370000 UNION
                       SELECT 144,370700,'Ϋ����',370000 UNION
                       SELECT 145,370800,'������',370000 UNION
                       SELECT 146,370900,'̩����',370000 UNION
                       SELECT 147,371000,'������',370000 UNION
                       SELECT 148,371100,'������',370000 UNION
                       SELECT 149,371200,'������',370000 UNION
                       SELECT 150,371300,'������',370000 UNION
                       SELECT 151,371400,'������',370000 UNION
                       SELECT 152,371500,'�ĳ���',370000 UNION
                       SELECT 153,371600,'������',370000 UNION
                       SELECT 154,371700,'������',370000 UNION
                       SELECT 155,410100,'֣����',410000 UNION
                       SELECT 156,410200,'������',410000 UNION
                       SELECT 157,410300,'������',410000 UNION
                       SELECT 158,410400,'ƽ��ɽ��',410000 UNION
                       SELECT 159,410500,'������',410000 UNION
                       SELECT 160,410600,'�ױ���',410000 UNION
                       SELECT 161,410700,'������',410000 UNION
                       SELECT 162,410800,'������',410000 UNION
                       SELECT 163,410900,'�����',410000 UNION
                       SELECT 164,411000,'�����',410000 UNION
                       SELECT 165,411100,'�����',410000 UNION
                       SELECT 166,411200,'����Ͽ��',410000 UNION
                       SELECT 167,411300,'������',410000 UNION
                       SELECT 168,411400,'������',410000 UNION
                       SELECT 169,411500,'������',410000 UNION
                       SELECT 170,411600,'�ܿ���',410000 UNION
                       SELECT 171,411700,'פ�����',410000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 172,420100,'�人��',420000 UNION
                       SELECT 173,420200,'��ʯ��',420000 UNION
                       SELECT 174,420300,'ʮ����',420000 UNION
                       SELECT 175,420500,'�˲���',420000 UNION
                       SELECT 176,420600,'�差��',420000 UNION
                       SELECT 177,420700,'������',420000 UNION
                       SELECT 178,420800,'������',420000 UNION
                       SELECT 179,420900,'Т����',420000 UNION
                       SELECT 180,421000,'������',420000 UNION
                       SELECT 181,421100,'�Ƹ���',420000 UNION
                       SELECT 182,421200,'������',420000 UNION
                       SELECT 183,421300,'������',420000 UNION
                       SELECT 184,422800,'��ʩ����������������',420000 UNION
                       SELECT 185,429000,'ʡֱϽ������λ',420000 UNION
                       SELECT 186,430100,'��ɳ��',430000 UNION
                       SELECT 187,430200,'������',430000 UNION
                       SELECT 188,430300,'��̶��',430000 UNION
                       SELECT 189,430400,'������',430000 UNION
                       SELECT 190,430500,'������',430000 UNION
                       SELECT 191,430600,'������',430000 UNION
                       SELECT 192,430700,'������',430000 UNION
                       SELECT 193,430800,'�żҽ���',430000 UNION
                       SELECT 194,430900,'������',430000 UNION
                       SELECT 195,431000,'������',430000 UNION
                       SELECT 196,431100,'������',430000 UNION
                       SELECT 197,431200,'������',430000 UNION
                       SELECT 198,431300,'¦����',430000 UNION
                       SELECT 199,433100,'��������������������',430000 UNION
                       SELECT 200,440100,'������',440000 UNION
                       SELECT 201,440200,'�ع���',440000 UNION
                       SELECT 202,440300,'������',440000 UNION
                       SELECT 203,440400,'�麣��',440000 UNION
                       SELECT 204,440500,'��ͷ��',440000 UNION
                       SELECT 205,440600,'��ɽ��',440000 UNION
                       SELECT 206,440700,'������',440000 UNION
                       SELECT 207,440800,'տ����',440000 UNION
                       SELECT 208,440900,'ï����',440000 UNION
                       SELECT 209,441200,'������',440000 UNION
                       SELECT 210,441300,'������',440000 UNION
                       SELECT 211,441400,'÷����',440000 UNION
                       SELECT 212,441500,'��β��',440000 UNION
                       SELECT 213,441600,'��Դ��',440000 UNION
                       SELECT 214,441700,'������',440000 UNION
                       SELECT 215,441800,'��Զ��',440000 UNION
                       SELECT 216,441900,'��ݸ��',440000 UNION
                       SELECT 217,442000,'��ɽ��',440000 UNION
                       SELECT 218,445100,'������',440000 UNION
                       SELECT 219,445200,'������',440000 UNION
                       SELECT 220,445300,'�Ƹ���',440000 UNION
                       SELECT 221,450100,'������',450000 UNION
                       SELECT 222,450200,'������',450000 UNION
                       SELECT 223,450300,'������',450000 UNION
                       SELECT 224,450400,'������',450000 UNION
                       SELECT 225,450500,'������',450000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 226,450600,'���Ǹ���',450000 UNION
                       SELECT 227,450700,'������',450000 UNION
                       SELECT 228,450800,'�����',450000 UNION
                       SELECT 229,450900,'������',450000 UNION
                       SELECT 230,451000,'��ɫ��',450000 UNION
                       SELECT 231,451100,'������',450000 UNION
                       SELECT 232,451200,'�ӳ���',450000 UNION
                       SELECT 233,451300,'������',450000 UNION
                       SELECT 234,451400,'������',450000 UNION
                       SELECT 235,460100,'������',460000 UNION
                       SELECT 236,460200,'������',460000 UNION
                       SELECT 237,469000,'ʡֱϽ�ؼ�������λ',460000 UNION
                       SELECT 238,500100,'��Ͻ��',500000 UNION
                       SELECT 239,500200,'��',500000 UNION
                       SELECT 240,500300,'��',500000 UNION
                       SELECT 241,510100,'�ɶ���',510000 UNION
                       SELECT 242,510300,'�Թ���',510000 UNION
                       SELECT 243,510400,'��֦����',510000 UNION
                       SELECT 244,510500,'������',510000 UNION
                       SELECT 245,510600,'������',510000 UNION
                       SELECT 246,510700,'������',510000 UNION
                       SELECT 247,510800,'��Ԫ��',510000 UNION
                       SELECT 248,510900,'������',510000 UNION
                       SELECT 249,511000,'�ڽ���',510000 UNION
                       SELECT 250,511100,'��ɽ��',510000 UNION
                       SELECT 251,511300,'�ϳ���',510000 UNION
                       SELECT 252,511400,'üɽ��',510000 UNION
                       SELECT 253,511500,'�˱���',510000 UNION
                       SELECT 254,511600,'�㰲��',510000 UNION
                       SELECT 255,511700,'������',510000 UNION
                       SELECT 256,511800,'�Ű���',510000 UNION
                       SELECT 257,511900,'������',510000 UNION
                       SELECT 258,512000,'������',510000 UNION
                       SELECT 259,513200,'���Ӳ���Ǽ��������',510000 UNION
                       SELECT 260,513300,'���β���������',510000 UNION
                       SELECT 261,513400,'��ɽ����������',510000 UNION
                       SELECT 262,520100,'������',520000 UNION
                       SELECT 263,520200,'����ˮ��',520000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 264,520300,'������',520000 UNION
                       SELECT 265,520400,'��˳��',520000 UNION
                       SELECT 266,522200,'ͭ�ʵ���',520000 UNION
                       SELECT 267,522300,'ǭ���ϲ���������������',520000 UNION
                       SELECT 268,522400,'�Ͻڵ���',520000 UNION
                       SELECT 269,522600,'ǭ�������嶱��������',520000 UNION
                       SELECT 270,522700,'ǭ�ϲ���������������',520000 UNION
                       SELECT 271,530100,'������',530000 UNION
                       SELECT 272,530300,'������',530000 UNION
                       SELECT 273,530400,'��Ϫ��',530000 UNION
                       SELECT 274,530500,'��ɽ��',530000 UNION
                       SELECT 275,530600,'��ͨ��',530000 UNION
                       SELECT 276,530700,'������',530000 UNION
                       SELECT 277,530800,'˼é��',530000 UNION
                       SELECT 278,530900,'�ٲ���',530000 UNION
                       SELECT 279,532300,'��������������',530000 UNION
                       SELECT 280,532500,'��ӹ���������������',530000 UNION
                       SELECT 281,532600,'��ɽ׳������������',530000 UNION
                       SELECT 282,532800,'��˫���ɴ���������',530000 UNION
                       SELECT 283,532900,'�������������',530000 UNION
                       SELECT 284,533100,'�º���徰����������',530000 UNION
                       SELECT 285,533300,'ŭ��������������',530000 UNION
                       SELECT 286,533400,'�������������',530000 UNION
                       SELECT 287,540100,'������',540000 UNION
                       SELECT 288,542100,'��������',540000 UNION
                       SELECT 289,542200,'ɽ�ϵ���',540000 UNION
                       SELECT 290,542300,'�տ������',540000 UNION
                       SELECT 291,542400,'��������',540000 UNION
                       SELECT 292,542500,'�������',540000 UNION
                       SELECT 293,542600,'��֥����',540000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 294,610100,'������',610000 UNION
                       SELECT 295,610200,'ͭ����',610000 UNION
                       SELECT 296,610300,'������',610000 UNION
                       SELECT 297,610400,'������',610000 UNION
                       SELECT 298,610500,'μ����',610000 UNION
                       SELECT 299,610600,'�Ӱ���',610000 UNION
                       SELECT 300,610700,'������',610000 UNION
                       SELECT 301,610800,'������',610000 UNION
                       SELECT 302,610900,'������',610000 UNION
                       SELECT 303,611000,'������',610000 UNION
                       SELECT 304,620100,'������',620000 UNION
                       SELECT 305,620200,'��������',620000 UNION
                       SELECT 306,620300,'�����',620000 UNION
                       SELECT 307,620400,'������',620000 UNION
                       SELECT 308,620500,'��ˮ��',620000 UNION
                       SELECT 309,620600,'������',620000 UNION
                       SELECT 310,620700,'��Ҵ��',620000 UNION
                       SELECT 311,620800,'ƽ����',620000 UNION
                       SELECT 312,620900,'��Ȫ��',620000 UNION
                       SELECT 313,621000,'������',620000 UNION
                       SELECT 314,621100,'������',620000 UNION
                       SELECT 315,621200,'¤����',620000 UNION
                       SELECT 316,622900,'���Ļ���������',620000 UNION
                       SELECT 317,623000,'���ϲ���������',620000 UNION
                       SELECT 318,630100,'������',630000 UNION
                       SELECT 319,632100,'��������',630000 UNION
                       SELECT 320,632200,'��������������',630000 UNION
                       SELECT 321,632300,'���ϲ���������',630000 UNION
                       SELECT 322,632500,'���ϲ���������',630000 UNION
                       SELECT 323,632600,'�������������',630000 UNION
                       SELECT 324,632700,'��������������',630000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 325,632800,'�����ɹ������������',630000 UNION
                       SELECT 326,640100,'������',640000 UNION
                       SELECT 327,640200,'ʯ��ɽ��',640000 UNION
                       SELECT 328,640300,'������',640000 UNION
                       SELECT 329,640400,'��ԭ��',640000 UNION
                       SELECT 330,640500,'������',640000 UNION
                       SELECT 331,650100,'��³ľ����',650000 UNION
                       SELECT 332,650200,'����������',650000 UNION
                       SELECT 333,652100,'��³������',650000 UNION
                       SELECT 334,652200,'���ܵ���',650000 UNION
                       SELECT 335,652300,'��������������',650000 UNION
                       SELECT 336,652700,'���������ɹ�������',650000 UNION
                       SELECT 337,652800,'���������ɹ�������',650000 UNION
                       SELECT 338,652900,'�����յ���',650000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 339,653000,'�������տ¶�����������',650000 UNION
                       SELECT 340,653100,'��ʲ����',650000 UNION
                       SELECT 341,653200,'�������',650000 UNION
                       SELECT 342,654000,'���������������',650000 UNION
                       SELECT 343,654200,'���ǵ���',650000 UNION
                       SELECT 344,654300,'����̩����',650000 UNION
                       SELECT 345,659000,'ʡֱϽ������λ',650000
                ");
        }

        public override void Down()
        {
            Sql(@"
                    TRUNCATE TABLE City
               ");
        }
    }
}
