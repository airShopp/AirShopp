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
                       SELECT 1,110100,N'��Ͻ��',110000 UNION
                       SELECT 2,110200,N'��',110000 UNION
                       SELECT 3,120100,N'��Ͻ��',120000 UNION
                       SELECT 4,120200,N'��',120000 UNION
                       SELECT 5,130100,N'ʯ��ׯ��',130000 UNION
                       SELECT 6,130200,N'��ɽ��',130000 UNION
                       SELECT 7,130300,N'�ػʵ���',130000 UNION
                       SELECT 8,130400,N'������',130000 UNION
                       SELECT 9,130500,N'��̨��',130000 UNION
                       SELECT 10,130600,N'������',130000 UNION
                       SELECT 11,130700,N'�żҿ���',130000 UNION
                       SELECT 12,130800,N'�е���',130000 UNION
                       SELECT 13,130900,N'������',130000 UNION
                       SELECT 14,131000,N'�ȷ���',130000 UNION
                       SELECT 15,131100,N'��ˮ��',130000 UNION
                       SELECT 16,140100,N'̫ԭ��',140000 UNION
                       SELECT 17,140200,N'��ͬ��',140000 UNION
                       SELECT 18,140300,N'��Ȫ��',140000 UNION
                       SELECT 19,140400,N'������',140000 UNION
                       SELECT 20,140500,N'������',140000 UNION
                       SELECT 21,140600,N'˷����',140000 UNION
                       SELECT 22,140700,N'������',140000 UNION
                       SELECT 23,140800,N'�˳���',140000 UNION
                       SELECT 24,140900,N'������',140000 UNION
                       SELECT 25,141000,N'�ٷ���',140000 UNION
                       SELECT 26,141100,N'������',140000

                       INSERT  City (ID,CityId,CityName,ProvinceId) 
                       SELECT 27,150100,N'���ͺ�����',150000 UNION
                       SELECT 28,150200,N'��ͷ��',150000 UNION
                       SELECT 29,150300,N'�ں���',150000 UNION
                       SELECT 30,150400,N'�����',150000 UNION
                       SELECT 31,150500,N'ͨ����',150000 UNION
                       SELECT 32,150600,N'������˹��',150000 UNION
                       SELECT 33,150700,N'���ױ�����',150000 UNION
                       SELECT 34,150800,N'�����׶���',150000 UNION
                       SELECT 35,150900,N'�����첼��',150000 UNION
                       SELECT 36,152200,N'�˰���',150000 UNION
                       SELECT 37,152500,N'���ֹ�����',150000 UNION
                       SELECT 38,152900,N'��������',150000 UNION
                       SELECT 39,210100,N'������',210000 UNION
                       SELECT 40,210200,N'������',210000 UNION
                       SELECT 41,210300,N'��ɽ��',210000 UNION
                       SELECT 42,210400,N'��˳��',210000 UNION
                       SELECT 43,210500,N'��Ϫ��',210000 UNION
                       SELECT 44,210600,N'������',210000 UNION
                       SELECT 45,210700,N'������',210000 UNION
                       SELECT 46,210800,N'Ӫ����',210000 UNION
                       SELECT 47,210900,N'������',210000 UNION
                       SELECT 48,211000,N'������',210000 UNION
                       SELECT 49,211100,N'�̽���',210000 UNION
                       SELECT 50,211200,N'������',210000 UNION
                       SELECT 51,211300,N'������',210000 UNION
                       SELECT 52,211400,N'��«����',210000 UNION
                       SELECT 53,220100,N'������',220000 UNION
                       SELECT 54,220200,N'������',220000 UNION
                       SELECT 55,220300,N'��ƽ��',220000 UNION
                       SELECT 56,220400,N'��Դ��',220000 UNION
                       SELECT 57,220500,N'ͨ����',220000 UNION
                       SELECT 58,220600,N'��ɽ��',220000 UNION
                       SELECT 59,220700,N'��ԭ��',220000 UNION
                       SELECT 60,220800,N'�׳���',220000 UNION
                       SELECT 61,222400,N'�ӱ߳�����������',220000 UNION
                       SELECT 62,230100,N'��������',230000 UNION
                       SELECT 63,230200,N'���������',230000 UNION
                       SELECT 64,230300,N'������',230000 UNION
                       SELECT 65,230400,N'�׸���',230000 UNION
                       SELECT 66,230500,N'˫Ѽɽ��',230000 UNION
                       SELECT 67,230600,N'������',230000 UNION
                       SELECT 68,230700,N'������',230000 UNION
                       SELECT 69,230800,N'��ľ˹��',230000 UNION
                       SELECT 70,230900,N'��̨����',230000 UNION
                       SELECT 71,231000,N'ĵ������',230000 UNION
                       SELECT 72,231100,N'�ں���',230000 UNION
                       SELECT 73,231200,N'�绯��',230000 UNION
                       SELECT 74,232700,N'���˰������',230000 UNION
                       SELECT 75,310100,N'��Ͻ��',310000 UNION
                       SELECT 76,310200,N'��',310000 UNION
                       SELECT 77,320100,N'�Ͼ���',320000 UNION
                       SELECT 78,320200,N'������',320000 UNION
                       SELECT 79,320300,N'������',320000 UNION
                       SELECT 80,320400,N'������',320000 UNION
                       SELECT 81,320500,N'������',320000 UNION
                       SELECT 82,320600,N'��ͨ��',320000 UNION
                       SELECT 83,320700,N'���Ƹ���',320000 UNION
                       SELECT 84,320800,N'������',320000 UNION
                       SELECT 85,320900,N'�γ���',320000 UNION
                       SELECT 86,321000,N'������',320000 UNION
                       SELECT 87,321100,N'����',320000 UNION
                       SELECT 88,321200,N'̩����',320000 UNION
                       SELECT 89,321300,N'��Ǩ��',320000 UNION
                       SELECT 90,330100,N'������',330000 UNION
                       SELECT 91,330200,N'������',330000 UNION
                       SELECT 92,330300,N'������',330000 UNION
                       SELECT 93,330400,N'������',330000 UNION
                       SELECT 94,330500,N'������',330000 UNION
                       SELECT 95,330600,N'������',330000 UNION
                       SELECT 96,330700,N'����',330000 UNION
                       SELECT 97,330800,N'������',330000 UNION
                       SELECT 98,330900,N'��ɽ��',330000 UNION
                       SELECT 99,331000,N'̨����',330000 UNION
                       SELECT 100,331100,N'��ˮ��',330000 UNION
                       SELECT 101,340100,N'�Ϸ���',340000 UNION
                       SELECT 102,340200,N'�ߺ���',340000 UNION
                       SELECT 103,340300,N'������',340000 UNION
                       SELECT 104,340400,N'������',340000 UNION
                       SELECT 105,340500,N'����ɽ��',340000 UNION
                       SELECT 106,340600,N'������',340000 UNION
                       SELECT 107,340700,N'ͭ����',340000 UNION
                       SELECT 108,340800,N'������',340000 UNION
                       SELECT 109,341000,N'��ɽ��',340000 UNION
                       SELECT 110,341100,N'������',340000 UNION
                       SELECT 111,341200,N'������',340000 UNION
                       SELECT 112,341300,N'������',340000 UNION
                       SELECT 113,341400,N'������',340000 UNION
                       SELECT 114,341500,N'������',340000 UNION
                       SELECT 115,341600,N'������',340000 UNION
                       SELECT 116,341700,N'������',340000 UNION
                       SELECT 117,341800,N'������',340000 UNION
                       SELECT 118,350100,N'������',350000 UNION
                       SELECT 119,350200,N'������',350000 UNION
                       SELECT 120,350300,N'������',350000 UNION
                       SELECT 121,350400,N'������',350000 UNION
                       SELECT 122,350500,N'Ȫ����',350000 UNION
                       SELECT 123,350600,N'������',350000 UNION
                       SELECT 124,350700,N'��ƽ��',350000 UNION
                       SELECT 125,350800,N'������',350000 UNION
                       SELECT 126,350900,N'������',350000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 127,360100,N'�ϲ���',360000 UNION
                       SELECT 128,360200,N'��������',360000 UNION
                       SELECT 129,360300,N'Ƽ����',360000 UNION
                       SELECT 130,360400,N'�Ž���',360000 UNION
                       SELECT 131,360500,N'������',360000 UNION
                       SELECT 132,360600,N'ӥ̶��',360000 UNION
                       SELECT 133,360700,N'������',360000 UNION
                       SELECT 134,360800,N'������',360000 UNION
                       SELECT 135,360900,N'�˴���',360000 UNION
                       SELECT 136,361000,N'������',360000 UNION
                       SELECT 137,361100,N'������',360000 UNION
                       SELECT 138,370100,N'������',370000 UNION
                       SELECT 139,370200,N'�ൺ��',370000 UNION
                       SELECT 140,370300,N'�Ͳ���',370000 UNION
                       SELECT 141,370400,N'��ׯ��',370000 UNION
                       SELECT 142,370500,N'��Ӫ��',370000 UNION
                       SELECT 143,370600,N'��̨��',370000 UNION
                       SELECT 144,370700,N'Ϋ����',370000 UNION
                       SELECT 145,370800,N'������',370000 UNION
                       SELECT 146,370900,N'̩����',370000 UNION
                       SELECT 147,371000,N'������',370000 UNION
                       SELECT 148,371100,N'������',370000 UNION
                       SELECT 149,371200,N'������',370000 UNION
                       SELECT 150,371300,N'������',370000 UNION
                       SELECT 151,371400,N'������',370000 UNION
                       SELECT 152,371500,N'�ĳ���',370000 UNION
                       SELECT 153,371600,N'������',370000 UNION
                       SELECT 154,371700,N'������',370000 UNION
                       SELECT 155,410100,N'֣����',410000 UNION
                       SELECT 156,410200,N'������',410000 UNION
                       SELECT 157,410300,N'������',410000 UNION
                       SELECT 158,410400,N'ƽ��ɽ��',410000 UNION
                       SELECT 159,410500,N'������',410000 UNION
                       SELECT 160,410600,N'�ױ���',410000 UNION
                       SELECT 161,410700,N'������',410000 UNION
                       SELECT 162,410800,N'������',410000 UNION
                       SELECT 163,410900,N'�����',410000 UNION
                       SELECT 164,411000,N'������',410000 UNION
                       SELECT 165,411100,N'�����',410000 UNION
                       SELECT 166,411200,N'����Ͽ��',410000 UNION
                       SELECT 167,411300,N'������',410000 UNION
                       SELECT 168,411400,N'������',410000 UNION
                       SELECT 169,411500,N'������',410000 UNION
                       SELECT 170,411600,N'�ܿ���',410000 UNION
                       SELECT 171,411700,N'פ������',410000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 172,420100,N'�人��',420000 UNION
                       SELECT 173,420200,N'��ʯ��',420000 UNION
                       SELECT 174,420300,N'ʮ����',420000 UNION
                       SELECT 175,420500,N'�˲���',420000 UNION
                       SELECT 176,420600,N'�差��',420000 UNION
                       SELECT 177,420700,N'������',420000 UNION
                       SELECT 178,420800,N'������',420000 UNION
                       SELECT 179,420900,N'Т����',420000 UNION
                       SELECT 180,421000,N'������',420000 UNION
                       SELECT 181,421100,N'�Ƹ���',420000 UNION
                       SELECT 182,421200,N'������',420000 UNION
                       SELECT 183,421300,N'������',420000 UNION
                       SELECT 184,422800,N'��ʩ����������������',420000 UNION
                       SELECT 185,429000,N'ʡֱϽ������λ',420000 UNION
                       SELECT 186,430100,N'��ɳ��',430000 UNION
                       SELECT 187,430200,N'������',430000 UNION
                       SELECT 188,430300,N'��̶��',430000 UNION
                       SELECT 189,430400,N'������',430000 UNION
                       SELECT 190,430500,N'������',430000 UNION
                       SELECT 191,430600,N'������',430000 UNION
                       SELECT 192,430700,N'������',430000 UNION
                       SELECT 193,430800,N'�żҽ���',430000 UNION
                       SELECT 194,430900,N'������',430000 UNION
                       SELECT 195,431000,N'������',430000 UNION
                       SELECT 196,431100,N'������',430000 UNION
                       SELECT 197,431200,N'������',430000 UNION
                       SELECT 198,431300,N'¦����',430000 UNION
                       SELECT 199,433100,N'��������������������',430000 UNION
                       SELECT 200,440100,N'������',440000 UNION
                       SELECT 201,440200,N'�ع���',440000 UNION
                       SELECT 202,440300,N'������',440000 UNION
                       SELECT 203,440400,N'�麣��',440000 UNION
                       SELECT 204,440500,N'��ͷ��',440000 UNION
                       SELECT 205,440600,N'��ɽ��',440000 UNION
                       SELECT 206,440700,N'������',440000 UNION
                       SELECT 207,440800,N'տ����',440000 UNION
                       SELECT 208,440900,N'ï����',440000 UNION
                       SELECT 209,441200,N'������',440000 UNION
                       SELECT 210,441300,N'������',440000 UNION
                       SELECT 211,441400,N'÷����',440000 UNION
                       SELECT 212,441500,N'��β��',440000 UNION
                       SELECT 213,441600,N'��Դ��',440000 UNION
                       SELECT 214,441700,N'������',440000 UNION
                       SELECT 215,441800,N'��Զ��',440000 UNION
                       SELECT 216,441900,N'��ݸ��',440000 UNION
                       SELECT 217,442000,N'��ɽ��',440000 UNION
                       SELECT 218,445100,N'������',440000 UNION
                       SELECT 219,445200,N'������',440000 UNION
                       SELECT 220,445300,N'�Ƹ���',440000 UNION
                       SELECT 221,450100,N'������',450000 UNION
                       SELECT 222,450200,N'������',450000 UNION
                       SELECT 223,450300,N'������',450000 UNION
                       SELECT 224,450400,N'������',450000 UNION
                       SELECT 225,450500,N'������',450000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 226,450600,N'���Ǹ���',450000 UNION
                       SELECT 227,450700,N'������',450000 UNION
                       SELECT 228,450800,N'�����',450000 UNION
                       SELECT 229,450900,N'������',450000 UNION
                       SELECT 230,451000,N'��ɫ��',450000 UNION
                       SELECT 231,451100,N'������',450000 UNION
                       SELECT 232,451200,N'�ӳ���',450000 UNION
                       SELECT 233,451300,N'������',450000 UNION
                       SELECT 234,451400,N'������',450000 UNION
                       SELECT 235,460100,N'������',460000 UNION
                       SELECT 236,460200,N'������',460000 UNION
                       SELECT 237,469000,N'ʡֱϽ�ؼ�������λ',460000 UNION
                       SELECT 238,500100,N'��Ͻ��',500000 UNION
                       SELECT 239,500200,N'��',500000 UNION
                       SELECT 240,500300,N'��',500000 UNION
                       SELECT 241,510100,N'�ɶ���',510000 UNION
                       SELECT 242,510300,N'�Թ���',510000 UNION
                       SELECT 243,510400,N'��֦����',510000 UNION
                       SELECT 244,510500,N'������',510000 UNION
                       SELECT 245,510600,N'������',510000 UNION
                       SELECT 246,510700,N'������',510000 UNION
                       SELECT 247,510800,N'��Ԫ��',510000 UNION
                       SELECT 248,510900,N'������',510000 UNION
                       SELECT 249,511000,N'�ڽ���',510000 UNION
                       SELECT 250,511100,N'��ɽ��',510000 UNION
                       SELECT 251,511300,N'�ϳ���',510000 UNION
                       SELECT 252,511400,N'üɽ��',510000 UNION
                       SELECT 253,511500,N'�˱���',510000 UNION
                       SELECT 254,511600,N'�㰲��',510000 UNION
                       SELECT 255,511700,N'������',510000 UNION
                       SELECT 256,511800,N'�Ű���',510000 UNION
                       SELECT 257,511900,N'������',510000 UNION
                       SELECT 258,512000,N'������',510000 UNION
                       SELECT 259,513200,N'���Ӳ���Ǽ��������',510000 UNION
                       SELECT 260,513300,N'���β���������',510000 UNION
                       SELECT 261,513400,N'��ɽ����������',510000 UNION
                       SELECT 262,520100,N'������',520000 UNION
                       SELECT 263,520200,N'����ˮ��',520000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 264,520300,N'������',520000 UNION
                       SELECT 265,520400,N'��˳��',520000 UNION
                       SELECT 266,522200,N'ͭ�ʵ���',520000 UNION
                       SELECT 267,522300,N'ǭ���ϲ���������������',520000 UNION
                       SELECT 268,522400,N'�Ͻڵ���',520000 UNION
                       SELECT 269,522600,N'ǭ�������嶱��������',520000 UNION
                       SELECT 270,522700,N'ǭ�ϲ���������������',520000 UNION
                       SELECT 271,530100,N'������',530000 UNION
                       SELECT 272,530300,N'������',530000 UNION
                       SELECT 273,530400,N'��Ϫ��',530000 UNION
                       SELECT 274,530500,N'��ɽ��',530000 UNION
                       SELECT 275,530600,N'��ͨ��',530000 UNION
                       SELECT 276,530700,N'������',530000 UNION
                       SELECT 277,530800,N'˼é��',530000 UNION
                       SELECT 278,530900,N'�ٲ���',530000 UNION
                       SELECT 279,532300,N'��������������',530000 UNION
                       SELECT 280,532500,N'��ӹ���������������',530000 UNION
                       SELECT 281,532600,N'��ɽ׳������������',530000 UNION
                       SELECT 282,532800,N'��˫���ɴ���������',530000 UNION
                       SELECT 283,532900,N'��������������',530000 UNION
                       SELECT 284,533100,N'�º���徰����������',530000 UNION
                       SELECT 285,533300,N'ŭ��������������',530000 UNION
                       SELECT 286,533400,N'�������������',530000 UNION
                       SELECT 287,540100,N'������',540000 UNION
                       SELECT 288,542100,N'��������',540000 UNION
                       SELECT 289,542200,N'ɽ�ϵ���',540000 UNION
                       SELECT 290,542300,N'�տ������',540000 UNION
                       SELECT 291,542400,N'��������',540000 UNION
                       SELECT 292,542500,N'�������',540000 UNION
                       SELECT 293,542600,N'��֥����',540000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 294,610100,N'������',610000 UNION
                       SELECT 295,610200,N'ͭ����',610000 UNION
                       SELECT 296,610300,N'������',610000 UNION
                       SELECT 297,610400,N'������',610000 UNION
                       SELECT 298,610500,N'μ����',610000 UNION
                       SELECT 299,610600,N'�Ӱ���',610000 UNION
                       SELECT 300,610700,N'������',610000 UNION
                       SELECT 301,610800,N'������',610000 UNION
                       SELECT 302,610900,N'������',610000 UNION
                       SELECT 303,611000,N'������',610000 UNION
                       SELECT 304,620100,N'������',620000 UNION
                       SELECT 305,620200,N'��������',620000 UNION
                       SELECT 306,620300,N'�����',620000 UNION
                       SELECT 307,620400,N'������',620000 UNION
                       SELECT 308,620500,N'��ˮ��',620000 UNION
                       SELECT 309,620600,N'������',620000 UNION
                       SELECT 310,620700,N'��Ҵ��',620000 UNION
                       SELECT 311,620800,N'ƽ����',620000 UNION
                       SELECT 312,620900,N'��Ȫ��',620000 UNION
                       SELECT 313,621000,N'������',620000 UNION
                       SELECT 314,621100,N'������',620000 UNION
                       SELECT 315,621200,N'¤����',620000 UNION
                       SELECT 316,622900,N'���Ļ���������',620000 UNION
                       SELECT 317,623000,N'���ϲ���������',620000 UNION
                       SELECT 318,630100,N'������',630000 UNION
                       SELECT 319,632100,N'��������',630000 UNION
                       SELECT 320,632200,N'��������������',630000 UNION
                       SELECT 321,632300,N'���ϲ���������',630000 UNION
                       SELECT 322,632500,N'���ϲ���������',630000 UNION
                       SELECT 323,632600,N'�������������',630000 UNION
                       SELECT 324,632700,N'��������������',630000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 325,632800,N'�����ɹ������������',630000 UNION
                       SELECT 326,640100,N'������',640000 UNION
                       SELECT 327,640200,N'ʯ��ɽ��',640000 UNION
                       SELECT 328,640300,N'������',640000 UNION
                       SELECT 329,640400,N'��ԭ��',640000 UNION
                       SELECT 330,640500,N'������',640000 UNION
                       SELECT 331,650100,N'��³ľ����',650000 UNION
                       SELECT 332,650200,N'����������',650000 UNION
                       SELECT 333,652100,N'��³������',650000 UNION
                       SELECT 334,652200,N'���ܵ���',650000 UNION
                       SELECT 335,652300,N'��������������',650000 UNION
                       SELECT 336,652700,N'���������ɹ�������',650000 UNION
                       SELECT 337,652800,N'���������ɹ�������',650000 UNION
                       SELECT 338,652900,N'�����յ���',650000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 339,653000,N'�������տ¶�����������',650000 UNION
                       SELECT 340,653100,N'��ʲ����',650000 UNION
                       SELECT 341,653200,N'�������',650000 UNION
                       SELECT 342,654000,N'���������������',650000 UNION
                       SELECT 343,654200,N'���ǵ���',650000 UNION
                       SELECT 344,654300,N'����̩����',650000 UNION
                       SELECT 345,659000,N'ʡֱϽ������λ',650000
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