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
                       SELECT 1,110100,N'市辖区',110000 UNION
                       SELECT 2,110200,N'县',110000 UNION
                       SELECT 3,120100,N'市辖区',120000 UNION
                       SELECT 4,120200,N'县',120000 UNION
                       SELECT 5,130100,N'石家庄市',130000 UNION
                       SELECT 6,130200,N'唐山市',130000 UNION
                       SELECT 7,130300,N'秦皇岛市',130000 UNION
                       SELECT 8,130400,N'邯郸市',130000 UNION
                       SELECT 9,130500,N'邢台市',130000 UNION
                       SELECT 10,130600,N'保定市',130000 UNION
                       SELECT 11,130700,N'张家口市',130000 UNION
                       SELECT 12,130800,N'承德市',130000 UNION
                       SELECT 13,130900,N'沧州市',130000 UNION
                       SELECT 14,131000,N'廊坊市',130000 UNION
                       SELECT 15,131100,N'衡水市',130000 UNION
                       SELECT 16,140100,N'太原市',140000 UNION
                       SELECT 17,140200,N'大同市',140000 UNION
                       SELECT 18,140300,N'阳泉市',140000 UNION
                       SELECT 19,140400,N'长治市',140000 UNION
                       SELECT 20,140500,N'晋城市',140000 UNION
                       SELECT 21,140600,N'朔州市',140000 UNION
                       SELECT 22,140700,N'晋中市',140000 UNION
                       SELECT 23,140800,N'运城市',140000 UNION
                       SELECT 24,140900,N'忻州市',140000 UNION
                       SELECT 25,141000,N'临汾市',140000 UNION
                       SELECT 26,141100,N'吕梁市',140000

                       INSERT  City (ID,CityId,CityName,ProvinceId) 
                       SELECT 27,150100,N'呼和浩特市',150000 UNION
                       SELECT 28,150200,N'包头市',150000 UNION
                       SELECT 29,150300,N'乌海市',150000 UNION
                       SELECT 30,150400,N'赤峰市',150000 UNION
                       SELECT 31,150500,N'通辽市',150000 UNION
                       SELECT 32,150600,N'鄂尔多斯市',150000 UNION
                       SELECT 33,150700,N'呼伦贝尔市',150000 UNION
                       SELECT 34,150800,N'巴彦淖尔市',150000 UNION
                       SELECT 35,150900,N'乌兰察布市',150000 UNION
                       SELECT 36,152200,N'兴安盟',150000 UNION
                       SELECT 37,152500,N'锡林郭勒盟',150000 UNION
                       SELECT 38,152900,N'阿拉善盟',150000 UNION
                       SELECT 39,210100,N'沈阳市',210000 UNION
                       SELECT 40,210200,N'大连市',210000 UNION
                       SELECT 41,210300,N'鞍山市',210000 UNION
                       SELECT 42,210400,N'抚顺市',210000 UNION
                       SELECT 43,210500,N'本溪市',210000 UNION
                       SELECT 44,210600,N'丹东市',210000 UNION
                       SELECT 45,210700,N'锦州市',210000 UNION
                       SELECT 46,210800,N'营口市',210000 UNION
                       SELECT 47,210900,N'阜新市',210000 UNION
                       SELECT 48,211000,N'辽阳市',210000 UNION
                       SELECT 49,211100,N'盘锦市',210000 UNION
                       SELECT 50,211200,N'铁岭市',210000 UNION
                       SELECT 51,211300,N'朝阳市',210000 UNION
                       SELECT 52,211400,N'葫芦岛市',210000 UNION
                       SELECT 53,220100,N'长春市',220000 UNION
                       SELECT 54,220200,N'吉林市',220000 UNION
                       SELECT 55,220300,N'四平市',220000 UNION
                       SELECT 56,220400,N'辽源市',220000 UNION
                       SELECT 57,220500,N'通化市',220000 UNION
                       SELECT 58,220600,N'白山市',220000 UNION
                       SELECT 59,220700,N'松原市',220000 UNION
                       SELECT 60,220800,N'白城市',220000 UNION
                       SELECT 61,222400,N'延边朝鲜族自治州',220000 UNION
                       SELECT 62,230100,N'哈尔滨市',230000 UNION
                       SELECT 63,230200,N'齐齐哈尔市',230000 UNION
                       SELECT 64,230300,N'鸡西市',230000 UNION
                       SELECT 65,230400,N'鹤岗市',230000 UNION
                       SELECT 66,230500,N'双鸭山市',230000 UNION
                       SELECT 67,230600,N'大庆市',230000 UNION
                       SELECT 68,230700,N'伊春市',230000 UNION
                       SELECT 69,230800,N'佳木斯市',230000 UNION
                       SELECT 70,230900,N'七台河市',230000 UNION
                       SELECT 71,231000,N'牡丹江市',230000 UNION
                       SELECT 72,231100,N'黑河市',230000 UNION
                       SELECT 73,231200,N'绥化市',230000 UNION
                       SELECT 74,232700,N'大兴安岭地区',230000 UNION
                       SELECT 75,310100,N'市辖区',310000 UNION
                       SELECT 76,310200,N'县',310000 UNION
                       SELECT 77,320100,N'南京市',320000 UNION
                       SELECT 78,320200,N'无锡市',320000 UNION
                       SELECT 79,320300,N'徐州市',320000 UNION
                       SELECT 80,320400,N'常州市',320000 UNION
                       SELECT 81,320500,N'苏州市',320000 UNION
                       SELECT 82,320600,N'南通市',320000 UNION
                       SELECT 83,320700,N'连云港市',320000 UNION
                       SELECT 84,320800,N'淮安市',320000 UNION
                       SELECT 85,320900,N'盐城市',320000 UNION
                       SELECT 86,321000,N'扬州市',320000 UNION
                       SELECT 87,321100,N'镇江市',320000 UNION
                       SELECT 88,321200,N'泰州市',320000 UNION
                       SELECT 89,321300,N'宿迁市',320000 UNION
                       SELECT 90,330100,N'杭州市',330000 UNION
                       SELECT 91,330200,N'宁波市',330000 UNION
                       SELECT 92,330300,N'温州市',330000 UNION
                       SELECT 93,330400,N'嘉兴市',330000 UNION
                       SELECT 94,330500,N'湖州市',330000 UNION
                       SELECT 95,330600,N'绍兴市',330000 UNION
                       SELECT 96,330700,N'金华市',330000 UNION
                       SELECT 97,330800,N'衢州市',330000 UNION
                       SELECT 98,330900,N'舟山市',330000 UNION
                       SELECT 99,331000,N'台州市',330000 UNION
                       SELECT 100,331100,N'丽水市',330000 UNION
                       SELECT 101,340100,N'合肥市',340000 UNION
                       SELECT 102,340200,N'芜湖市',340000 UNION
                       SELECT 103,340300,N'蚌埠市',340000 UNION
                       SELECT 104,340400,N'淮南市',340000 UNION
                       SELECT 105,340500,N'马鞍山市',340000 UNION
                       SELECT 106,340600,N'淮北市',340000 UNION
                       SELECT 107,340700,N'铜陵市',340000 UNION
                       SELECT 108,340800,N'安庆市',340000 UNION
                       SELECT 109,341000,N'黄山市',340000 UNION
                       SELECT 110,341100,N'滁州市',340000 UNION
                       SELECT 111,341200,N'阜阳市',340000 UNION
                       SELECT 112,341300,N'宿州市',340000 UNION
                       SELECT 113,341400,N'巢湖市',340000 UNION
                       SELECT 114,341500,N'六安市',340000 UNION
                       SELECT 115,341600,N'亳州市',340000 UNION
                       SELECT 116,341700,N'池州市',340000 UNION
                       SELECT 117,341800,N'宣城市',340000 UNION
                       SELECT 118,350100,N'福州市',350000 UNION
                       SELECT 119,350200,N'厦门市',350000 UNION
                       SELECT 120,350300,N'莆田市',350000 UNION
                       SELECT 121,350400,N'三明市',350000 UNION
                       SELECT 122,350500,N'泉州市',350000 UNION
                       SELECT 123,350600,N'漳州市',350000 UNION
                       SELECT 124,350700,N'南平市',350000 UNION
                       SELECT 125,350800,N'龙岩市',350000 UNION
                       SELECT 126,350900,N'宁德市',350000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 127,360100,N'南昌市',360000 UNION
                       SELECT 128,360200,N'景德镇市',360000 UNION
                       SELECT 129,360300,N'萍乡市',360000 UNION
                       SELECT 130,360400,N'九江市',360000 UNION
                       SELECT 131,360500,N'新余市',360000 UNION
                       SELECT 132,360600,N'鹰潭市',360000 UNION
                       SELECT 133,360700,N'赣州市',360000 UNION
                       SELECT 134,360800,N'吉安市',360000 UNION
                       SELECT 135,360900,N'宜春市',360000 UNION
                       SELECT 136,361000,N'抚州市',360000 UNION
                       SELECT 137,361100,N'上饶市',360000 UNION
                       SELECT 138,370100,N'济南市',370000 UNION
                       SELECT 139,370200,N'青岛市',370000 UNION
                       SELECT 140,370300,N'淄博市',370000 UNION
                       SELECT 141,370400,N'枣庄市',370000 UNION
                       SELECT 142,370500,N'东营市',370000 UNION
                       SELECT 143,370600,N'烟台市',370000 UNION
                       SELECT 144,370700,N'潍坊市',370000 UNION
                       SELECT 145,370800,N'济宁市',370000 UNION
                       SELECT 146,370900,N'泰安市',370000 UNION
                       SELECT 147,371000,N'威海市',370000 UNION
                       SELECT 148,371100,N'日照市',370000 UNION
                       SELECT 149,371200,N'莱芜市',370000 UNION
                       SELECT 150,371300,N'临沂市',370000 UNION
                       SELECT 151,371400,N'德州市',370000 UNION
                       SELECT 152,371500,N'聊城市',370000 UNION
                       SELECT 153,371600,N'滨州市',370000 UNION
                       SELECT 154,371700,N'荷泽市',370000 UNION
                       SELECT 155,410100,N'郑州市',410000 UNION
                       SELECT 156,410200,N'开封市',410000 UNION
                       SELECT 157,410300,N'洛阳市',410000 UNION
                       SELECT 158,410400,N'平顶山市',410000 UNION
                       SELECT 159,410500,N'安阳市',410000 UNION
                       SELECT 160,410600,N'鹤壁市',410000 UNION
                       SELECT 161,410700,N'新乡市',410000 UNION
                       SELECT 162,410800,N'焦作市',410000 UNION
                       SELECT 163,410900,N'濮阳市',410000 UNION
                       SELECT 164,411000,N'许昌市',410000 UNION
                       SELECT 165,411100,N'漯河市',410000 UNION
                       SELECT 166,411200,N'三门峡市',410000 UNION
                       SELECT 167,411300,N'南阳市',410000 UNION
                       SELECT 168,411400,N'商丘市',410000 UNION
                       SELECT 169,411500,N'信阳市',410000 UNION
                       SELECT 170,411600,N'周口市',410000 UNION
                       SELECT 171,411700,N'驻马店市',410000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 172,420100,N'武汉市',420000 UNION
                       SELECT 173,420200,N'黄石市',420000 UNION
                       SELECT 174,420300,N'十堰市',420000 UNION
                       SELECT 175,420500,N'宜昌市',420000 UNION
                       SELECT 176,420600,N'襄樊市',420000 UNION
                       SELECT 177,420700,N'鄂州市',420000 UNION
                       SELECT 178,420800,N'荆门市',420000 UNION
                       SELECT 179,420900,N'孝感市',420000 UNION
                       SELECT 180,421000,N'荆州市',420000 UNION
                       SELECT 181,421100,N'黄冈市',420000 UNION
                       SELECT 182,421200,N'咸宁市',420000 UNION
                       SELECT 183,421300,N'随州市',420000 UNION
                       SELECT 184,422800,N'恩施土家族苗族自治州',420000 UNION
                       SELECT 185,429000,N'省直辖行政单位',420000 UNION
                       SELECT 186,430100,N'长沙市',430000 UNION
                       SELECT 187,430200,N'株洲市',430000 UNION
                       SELECT 188,430300,N'湘潭市',430000 UNION
                       SELECT 189,430400,N'衡阳市',430000 UNION
                       SELECT 190,430500,N'邵阳市',430000 UNION
                       SELECT 191,430600,N'岳阳市',430000 UNION
                       SELECT 192,430700,N'常德市',430000 UNION
                       SELECT 193,430800,N'张家界市',430000 UNION
                       SELECT 194,430900,N'益阳市',430000 UNION
                       SELECT 195,431000,N'郴州市',430000 UNION
                       SELECT 196,431100,N'永州市',430000 UNION
                       SELECT 197,431200,N'怀化市',430000 UNION
                       SELECT 198,431300,N'娄底市',430000 UNION
                       SELECT 199,433100,N'湘西土家族苗族自治州',430000 UNION
                       SELECT 200,440100,N'广州市',440000 UNION
                       SELECT 201,440200,N'韶关市',440000 UNION
                       SELECT 202,440300,N'深圳市',440000 UNION
                       SELECT 203,440400,N'珠海市',440000 UNION
                       SELECT 204,440500,N'汕头市',440000 UNION
                       SELECT 205,440600,N'佛山市',440000 UNION
                       SELECT 206,440700,N'江门市',440000 UNION
                       SELECT 207,440800,N'湛江市',440000 UNION
                       SELECT 208,440900,N'茂名市',440000 UNION
                       SELECT 209,441200,N'肇庆市',440000 UNION
                       SELECT 210,441300,N'惠州市',440000 UNION
                       SELECT 211,441400,N'梅州市',440000 UNION
                       SELECT 212,441500,N'汕尾市',440000 UNION
                       SELECT 213,441600,N'河源市',440000 UNION
                       SELECT 214,441700,N'阳江市',440000 UNION
                       SELECT 215,441800,N'清远市',440000 UNION
                       SELECT 216,441900,N'东莞市',440000 UNION
                       SELECT 217,442000,N'中山市',440000 UNION
                       SELECT 218,445100,N'潮州市',440000 UNION
                       SELECT 219,445200,N'揭阳市',440000 UNION
                       SELECT 220,445300,N'云浮市',440000 UNION
                       SELECT 221,450100,N'南宁市',450000 UNION
                       SELECT 222,450200,N'柳州市',450000 UNION
                       SELECT 223,450300,N'桂林市',450000 UNION
                       SELECT 224,450400,N'梧州市',450000 UNION
                       SELECT 225,450500,N'北海市',450000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 226,450600,N'防城港市',450000 UNION
                       SELECT 227,450700,N'钦州市',450000 UNION
                       SELECT 228,450800,N'贵港市',450000 UNION
                       SELECT 229,450900,N'玉林市',450000 UNION
                       SELECT 230,451000,N'百色市',450000 UNION
                       SELECT 231,451100,N'贺州市',450000 UNION
                       SELECT 232,451200,N'河池市',450000 UNION
                       SELECT 233,451300,N'来宾市',450000 UNION
                       SELECT 234,451400,N'崇左市',450000 UNION
                       SELECT 235,460100,N'海口市',460000 UNION
                       SELECT 236,460200,N'三亚市',460000 UNION
                       SELECT 237,469000,N'省直辖县级行政单位',460000 UNION
                       SELECT 238,500100,N'市辖区',500000 UNION
                       SELECT 239,500200,N'县',500000 UNION
                       SELECT 240,500300,N'市',500000 UNION
                       SELECT 241,510100,N'成都市',510000 UNION
                       SELECT 242,510300,N'自贡市',510000 UNION
                       SELECT 243,510400,N'攀枝花市',510000 UNION
                       SELECT 244,510500,N'泸州市',510000 UNION
                       SELECT 245,510600,N'德阳市',510000 UNION
                       SELECT 246,510700,N'绵阳市',510000 UNION
                       SELECT 247,510800,N'广元市',510000 UNION
                       SELECT 248,510900,N'遂宁市',510000 UNION
                       SELECT 249,511000,N'内江市',510000 UNION
                       SELECT 250,511100,N'乐山市',510000 UNION
                       SELECT 251,511300,N'南充市',510000 UNION
                       SELECT 252,511400,N'眉山市',510000 UNION
                       SELECT 253,511500,N'宜宾市',510000 UNION
                       SELECT 254,511600,N'广安市',510000 UNION
                       SELECT 255,511700,N'达州市',510000 UNION
                       SELECT 256,511800,N'雅安市',510000 UNION
                       SELECT 257,511900,N'巴中市',510000 UNION
                       SELECT 258,512000,N'资阳市',510000 UNION
                       SELECT 259,513200,N'阿坝藏族羌族自治州',510000 UNION
                       SELECT 260,513300,N'甘孜藏族自治州',510000 UNION
                       SELECT 261,513400,N'凉山彝族自治州',510000 UNION
                       SELECT 262,520100,N'贵阳市',520000 UNION
                       SELECT 263,520200,N'六盘水市',520000

                       INSERT  City (ID,CityID,CityName,ProvinceId) 
                       SELECT 264,520300,N'遵义市',520000 UNION
                       SELECT 265,520400,N'安顺市',520000 UNION
                       SELECT 266,522200,N'铜仁地区',520000 UNION
                       SELECT 267,522300,N'黔西南布依族苗族自治州',520000 UNION
                       SELECT 268,522400,N'毕节地区',520000 UNION
                       SELECT 269,522600,N'黔东南苗族侗族自治州',520000 UNION
                       SELECT 270,522700,N'黔南布依族苗族自治州',520000 UNION
                       SELECT 271,530100,N'昆明市',530000 UNION
                       SELECT 272,530300,N'曲靖市',530000 UNION
                       SELECT 273,530400,N'玉溪市',530000 UNION
                       SELECT 274,530500,N'保山市',530000 UNION
                       SELECT 275,530600,N'昭通市',530000 UNION
                       SELECT 276,530700,N'丽江市',530000 UNION
                       SELECT 277,530800,N'思茅市',530000 UNION
                       SELECT 278,530900,N'临沧市',530000 UNION
                       SELECT 279,532300,N'楚雄彝族自治州',530000 UNION
                       SELECT 280,532500,N'红河哈尼族彝族自治州',530000 UNION
                       SELECT 281,532600,N'文山壮族苗族自治州',530000 UNION
                       SELECT 282,532800,N'西双版纳傣族自治州',530000 UNION
                       SELECT 283,532900,N'大理白族自治州',530000 UNION
                       SELECT 284,533100,N'德宏傣族景颇族自治州',530000 UNION
                       SELECT 285,533300,N'怒江傈僳族自治州',530000 UNION
                       SELECT 286,533400,N'迪庆藏族自治州',530000 UNION
                       SELECT 287,540100,N'拉萨市',540000 UNION
                       SELECT 288,542100,N'昌都地区',540000 UNION
                       SELECT 289,542200,N'山南地区',540000 UNION
                       SELECT 290,542300,N'日喀则地区',540000 UNION
                       SELECT 291,542400,N'那曲地区',540000 UNION
                       SELECT 292,542500,N'阿里地区',540000 UNION
                       SELECT 293,542600,N'林芝地区',540000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 294,610100,N'西安市',610000 UNION
                       SELECT 295,610200,N'铜川市',610000 UNION
                       SELECT 296,610300,N'宝鸡市',610000 UNION
                       SELECT 297,610400,N'咸阳市',610000 UNION
                       SELECT 298,610500,N'渭南市',610000 UNION
                       SELECT 299,610600,N'延安市',610000 UNION
                       SELECT 300,610700,N'汉中市',610000 UNION
                       SELECT 301,610800,N'榆林市',610000 UNION
                       SELECT 302,610900,N'安康市',610000 UNION
                       SELECT 303,611000,N'商洛市',610000 UNION
                       SELECT 304,620100,N'兰州市',620000 UNION
                       SELECT 305,620200,N'嘉峪关市',620000 UNION
                       SELECT 306,620300,N'金昌市',620000 UNION
                       SELECT 307,620400,N'白银市',620000 UNION
                       SELECT 308,620500,N'天水市',620000 UNION
                       SELECT 309,620600,N'武威市',620000 UNION
                       SELECT 310,620700,N'张掖市',620000 UNION
                       SELECT 311,620800,N'平凉市',620000 UNION
                       SELECT 312,620900,N'酒泉市',620000 UNION
                       SELECT 313,621000,N'庆阳市',620000 UNION
                       SELECT 314,621100,N'定西市',620000 UNION
                       SELECT 315,621200,N'陇南市',620000 UNION
                       SELECT 316,622900,N'临夏回族自治州',620000 UNION
                       SELECT 317,623000,N'甘南藏族自治州',620000 UNION
                       SELECT 318,630100,N'西宁市',630000 UNION
                       SELECT 319,632100,N'海东地区',630000 UNION
                       SELECT 320,632200,N'海北藏族自治州',630000 UNION
                       SELECT 321,632300,N'黄南藏族自治州',630000 UNION
                       SELECT 322,632500,N'海南藏族自治州',630000 UNION
                       SELECT 323,632600,N'果洛藏族自治州',630000 UNION
                       SELECT 324,632700,N'玉树藏族自治州',630000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 325,632800,N'海西蒙古族藏族自治州',630000 UNION
                       SELECT 326,640100,N'银川市',640000 UNION
                       SELECT 327,640200,N'石嘴山市',640000 UNION
                       SELECT 328,640300,N'吴忠市',640000 UNION
                       SELECT 329,640400,N'固原市',640000 UNION
                       SELECT 330,640500,N'中卫市',640000 UNION
                       SELECT 331,650100,N'乌鲁木齐市',650000 UNION
                       SELECT 332,650200,N'克拉玛依市',650000 UNION
                       SELECT 333,652100,N'吐鲁番地区',650000 UNION
                       SELECT 334,652200,N'哈密地区',650000 UNION
                       SELECT 335,652300,N'昌吉回族自治州',650000 UNION
                       SELECT 336,652700,N'博尔塔拉蒙古自治州',650000 UNION
                       SELECT 337,652800,N'巴音郭楞蒙古自治州',650000 UNION
                       SELECT 338,652900,N'阿克苏地区',650000

                       INSERT  City (Id,CityId,CityName,ProvinceId) 
                       SELECT 339,653000,N'克孜勒苏柯尔克孜自治州',650000 UNION
                       SELECT 340,653100,N'喀什地区',650000 UNION
                       SELECT 341,653200,N'和田地区',650000 UNION
                       SELECT 342,654000,N'伊犁哈萨克自治州',650000 UNION
                       SELECT 343,654200,N'塔城地区',650000 UNION
                       SELECT 344,654300,N'阿勒泰地区',650000 UNION
                       SELECT 345,659000,N'省直辖行政单位',650000
                ");
        }

        public override void Down()
        {
            Sql(@"
                    DELETE FROM  dbo.City
               ");
        }
    }
}
