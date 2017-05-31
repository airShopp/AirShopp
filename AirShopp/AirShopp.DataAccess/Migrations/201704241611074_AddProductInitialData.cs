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
                    --电器
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(1,'原装中兴充电器 5V1A手机电源适配器 USB充电头5V0.7A设备电源',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/中兴充电器.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(2,'小米M4 红米note3手机原装正品拆机数据线快速闪充充电器直充头2a',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/红米数据线.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(3,'VIVO充电器原装X6 X7 plus X9双引擎闪充头V3max手机数据线Xplay5',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/Vivo充电器.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(4,'华为原装充电器荣耀4C 3C 4A畅玩4X 3X C8818 G610手机数据线充头',1,1,GETUTCDATE(),'三年',200,'待定项',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(5,'8口USB快速充电器头手机平板智能显示多口多功能手机通用排插座2A',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/8口USB快速充电器.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(6,'舜红正品500W变压器220V转110V日本美国电器110V转220V电压变压器',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/舜红500W变压器.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(7,'三星充电器原装正品S6edge s7 note4/5手机快充头A8/9V原装数据线',1,1,GETUTCDATE(),'三年',200,'待定项',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(8,'华为原装充电器4X 5X荣耀6 Plus Mate8 7 P8数据线手机充电器通用',1,1,GETUTCDATE(),'三年',200,'/Content/img/product/华为充电头.jpg',NULL,1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(9,'索尼原装充电器快充头正品Z1 Z2 Z3 L36H C5 Z5 Z4 Z5P手机数据线',1,1,GETUTCDATE(),'三年',200,'待定项',NULL,1);
                    --服饰
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(10,'嘻哈t恤女装ds演出服上衣宽松爵士舞舞蹈服高腰露脐短袖成人服装', 2, 8, GETUTCDATE(), '三年', 300,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(11,'2017仙公主网络直播衣服装美女装主播上镜露肩小姐夜店性感连衣裙', 2, 8, GETUTCDATE(), '三年', 300,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(12,'2017新款江南雨表演服伞舞演出服民族扇子舞秧歌服装古典舞蹈服女', 2, 8, GETUTCDATE(), '三年', 300,'/Content/img/product/舞蹈服.jpg','本款服装采用优质高丝宝和雪纺布料精心制作而成  布料穿着舒适透气性好   款式简约而不简单    大方而不俗气   适合演绎各种舞蹈      现在购买还送同款头饰    也可以联系客服换其他款式头饰    一套包邮 （偏远地区除外）',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(13,'胸围120大码女装夏韩版胖MM个性潮蝙蝠衫 短袖T恤 胖人服装显瘦衣', 2, 8, GETUTCDATE(), '三年', 300,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(14,'宠物服饰狗狗衣服两脚衣春夏装小泰迪犬猫咪博美比熊幼犬狗衣服', 2, 8, GETUTCDATE(), '三年', 300,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(15,'酒店工作服夏装女 西餐厅服务员服装短袖 火锅店餐饮服务员制服', 2, 8, GETUTCDATE(), '三年', 300,'/Content/img/product/服装短袖.jpg','北京工作服工厂店网上直销。单上衣送围裙现在活动特价28元送围裙（数量有限送完为止），数量有限，预购从速。售完为止。  女士尺码偏小，亲们可以咨询客服啊。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(16,'结婚登记证件照情侣服装男女长袖纯棉白衬衣领证拍照上衣尖领衬衫', 2, 8, GETUTCDATE(), '三年', 300,'待定项','结婚登记证件照情侣服装男女长袖棉质白衬衣领证拍照上衣尖领衬衫',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(17,'藏族舞蹈服女少数民族服装舞台演出服成人西藏表演服水袖长裙服饰', 2, 8, GETUTCDATE(), '三年', 300,'待定项','亲，多款选择！多颜色选择！不要错过哦！这款藏族服是高档麻丁面料，容易洗涤、不缩水、不掉色、穿着舒适；不像市场上仿缎面料，容易抽丝，而且轻飘吸身，下摆比裙体本身的缎料还轻！，，不是轻飘的缎料，增加了裙子的坠感！让您的舞姿更加自然优美。请亲们分辨清楚哦！',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(18,'九唐服饰奥迪4S店销售斜门襟长袖女衬衫工服白衬衣职业装工作制服', 2, 8, GETUTCDATE(), '三年', 300,'待定项','亲购买时祥请参照尺码表哦。可开发票,请亲放心购买， 能过标检。尺寸不合适可以免费修改和退换。30件以上可支持定制，可绣LOGO，全国定制热线：0574-88355000',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(19,'泡泡袖 宠物服装幼犬猫咪吉娃娃博美比熊泰迪狗狗衣服春夏季衬衫', 2, 8, GETUTCDATE(), '三年', 300,'待定项','很大方的经典条纹款式~超级百搭的哦！春夏可以单穿~秋冬可以做打底衫~也可以用来搭配背带裤~超级实用哦！',1);
                    --母婴
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(20,'【第二件半价】韩国每日坚果 混合燕麦果仁 儿童妇女零食20g*30袋',8,9,GETUTCDATE(),'两年',200,'待定项','一盒30袋套餐，一天一袋，囤货一月，补充每天营养。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(21,'Floradix Iron德国药店铁元绿色妇女儿童孕产妇口服液500ml',8,9,GETUTCDATE(),'两年',200,'/Content/img/product/口服液.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(22,'包邮正版 大鱼/（美）丹尼尔&middot;华莱士著，宁蒙译/北方妇女儿童出',8,9,GETUTCDATE(),'两年',200,'/Content/img/product/书.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(23,'妇女节幼儿园手工节日花盆礼物玩具diy儿童手工制作材料包',8,9,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(24,'创意婚庆蛋糕毛巾实用妇女节礼物儿童 公司活动促销小礼品定制品',8,9,GETUTCDATE(),'两年',200,'/Content/img/product/蛋糕毛巾.jpg','纯棉毛巾，手工制作，可爱的造型，总有一款适合您，欢迎选购，产品定制200个起！',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(25,'妇女节礼物幼儿园创意儿童小礼品义乌小商品小玩意手环玩具批發',8,9,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                     VALUES(26,'三八妇女节DIY手工贺卡材料包 手绘涂鸦贴纸儿童自制作38送老师',8,9,GETUTCDATE(),'两年',200,'待定项','内附彩色说明书。一套6张，儿童零基础手工。',1);
 
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(27,'妇女母亲节亲子手工diy纽扣扣子花束制作材料包 儿童益智玩具',8,9,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(28,'妇女母亲节EVA免裁剪手工带钻花盆栽儿童幼儿园亲子diy制作材料包',8,9,GETUTCDATE(),'两年',200,'待定项','',1);
                    --化妆品
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(29,'百雀羚面膜水嫩精纯明星睡眠面膜200g免洗补水保湿女士护肤品正品',5,10,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(30,'温碧泉套装专柜正品长效保湿水乳化妆品套盒控油补水护肤品套装女',5,10,GETUTCDATE(),'两年',200,'待定项','深层清洁 补水保湿控油 提亮肤色',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(31,'兰亭男士营养润肤露100ml 乳液面霜控油美白补水保湿护肤品正品',5,10,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(32,'代购雅诗兰黛红石榴护肤品小样套装正品美白保湿滋润化妆旅行包邮',5,10,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(33,'碧妮爽肤水乳液精华液男女深度补水化妆柔肤水保湿美白控油护肤品',5,10,GETUTCDATE(),'两年',200,'待定项','水 乳 精华液 三合一  买2送1',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(34,'祛斑美白套装去黄美白祛斑霜产品男女淡斑去斑补水正品化妆护肤品',5,10,GETUTCDATE(),'两年',200,'/Content/img/product/补水化妆品.jpg','氧疗祛斑套装  用后30天 不满意就退款',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(35,'旋转透明亚克力化妆品收纳盒桌面梳妆台护肤品整理置物架大号韩国',5,10,GETUTCDATE(),'两年',200,'待定项','化妆品收纳盒，360度旋转，超大容量 护肤品，彩妆收纳，透明亚克力材质。托盘可以根据护肤品高度调节。家用多功能梳妆台洗手台整理韩国储物盒超大号收纳神器。打破格局，高瓶、低瓶、护肤品、彩妆全部能装，做到真正的一目了然和随意拿放。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(36,'浴室护肤品大号化妆品收纳盒桌面抽屉式梳妆台办公桌储物盒置物架',5,10,GETUTCDATE(),'两年',200,'待定项','防水 环保 容量大 多功能',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(37,'包邮旅行套装分装硅胶1个洗漱包户旅游洗发化妆外用水空瓶品瓶',5,10,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(38,'包邮化妆套装分装洗发洗漱硅胶旅游外用包户旅行1个水空瓶品瓶',5,10,GETUTCDATE(),'两年',200,'待定项','',1);
                    --家居
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(39,'名翔 花瓶摆件客厅插花家居装饰品干花花瓶简约现代陶瓷花瓶',3,7,GETUTCDATE(),'两年',200,'待定项','破损包赔，简约现代陶瓷花瓶！花瓶花艺  软装百搭',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(40,'创意客厅背景墙面家居软装饰品欧式墙上挂件儿童卧室床头壁饰挂饰',3,7,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(41,'欧式复古跳舞芭蕾女孩摆件美女人物摆设创意生日礼物家居饰品礼品',3,7,GETUTCDATE(),'两年',200,'待定项','优美的弧线，艺术的造型，不免让人为它心动，质优价廉，包装是防震抗摔双层硬纸箱包装，包装厚实，大量现货，亲可以放心拍下哈，此次活动限时限量哦，将不定时涨价哦！',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(42,'10双包邮一次性拖鞋 白色珊瑚绒拖鞋 家居待客拖鞋 客房半包拖鞋',3,7,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(43,'开光中国结黄铜五帝钱六帝钱仿古钱挂件旺财招财挂件家居风水用品',3,7,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(44,'粗陶白瓷干花满天星花瓶简约现代白色插花家居客厅陶瓷摆件小花器',3,7,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(45,'冬夏季家居四季男女情侣棉麻亚麻拖鞋居家室内木地板软底防滑布春',3,7,GETUTCDATE(),'两年',200,'/Content/img/product/防滑布.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(46,'【天天特价】招财玉白菜摆件笔筒家居办公室桌工艺品创意开业礼品',3,7,GETUTCDATE(),'两年',200,'待定项','白菜笔筒，做工精致，实用，送朋友，送长辈，送老师，送老板首选，百分比实拍绝对无ps，全国包邮！！！',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(47,'棉拖鞋女冬季情侣半包跟家居室内防滑保暖厚底冬天儿童毛拖鞋男士',3,7,GETUTCDATE(),'两年',200,'待定项','简约家居  防滑保暖  厂家直销',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(48,'天天特价居家拖鞋女夏地板室内亚麻拖鞋男家居麻拖鞋 夏季凉拖鞋',3,7,GETUTCDATE(),'两年',200,'待定项','',1);
                    --健身
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(49,'夏季轻薄透气运动短袖速干t恤宽松镂空健身跑步瑜伽训练上衣罩衫',6,5,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(50,'菩媞春夏季新款瑜伽服舞韵瑜珈服人棉愈加雪纺舞蹈衣健身服女纱裤',6,5,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(51,'体态大师 瑜伽垫多色男女健身防滑加长加厚TPE环保无味运动健身垫',6,5,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(52,'特价狂神哑铃2/4/8/10/12LB家用健身哑铃6磅彩色浸塑男士女士瘦臂',6,5,GETUTCDATE(),'两年',200,'待定项','亲哑铃江浙沪安徽包邮，广东福建江西湖南湖北河南河北北京天津3元一只邮费。东北三省、云南贵州四川重庆山西陕西海南邮费15元一只，其他地区不包邮，按拍下收邮费。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(53,'双林臂力器40kg30握力棒扩胸器肌训练健身器材臂力棒60公斤50公斤',6,5,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(54,'INSANITY加长加宽健身垫防滑减震跳操垫隔音运动垫瑜伽垫T25/KEEP',6,5,GETUTCDATE(),'两年',200,'待定项','专门为高强度的健身训练如INSANITY/T25/赵奕然/这样的增强式训练而设计的。你会感谢这款具有超强吸震能力的健身垫对你的膝盖、后背和踝关节起到的保护作用。所有的家庭室内健身都不能没有它。感谢亲们一如既往的支持，针对有些亲们的建议特推出了这款长198cm宽94cm 厚度6mm 的清新版跳操垫',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(55,'医用关节保暖护肘护臂运动健身超薄透气春夏季男女篮球羽毛球网球',6,5,GETUTCDATE(),'两年',200,'待定项','1、杜邦莱卡弹性纱、不易松弛，轻便、柔软、回弹性好。 2、一体成型无缝织造工艺、人体工学设计，贴近关节和肌肉结构，穿著舒适贴服，受力均衡，有支撑作用。 3、循序减压设计，保护关节部位。 4、透气性和吸湿性。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(56,'胖mm大码瑜伽服女套装春夏季健身房跑步运动假两件裤短袖速干显瘦',6,5,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale)
                    VALUES(57,'瑜伽垫健身垫加长加宽80初学者防滑瑜伽毯加厚运动垫子瑜珈垫正品',6,5,GETUTCDATE(),'两年',200,'待定项','185cmX80cm，加厚10mm，多种颜色可选 运动专用垫。 【高品质】柔软舒适、无味环保、防滑防潮抗寒。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(58,'瑜伽垫加厚15mm加长加宽80cm健身垫子防滑无味瑜伽毯微瑕疵品特价',6,5,GETUTCDATE(),'两年',200,'待定项','加长185cm   加宽90cm   加厚15mm  高密度高回弹   性价比超高',1);
                    --食品
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(59,'新货麦吉士小酥山核桃味/芝麻/花生味零食品一口酥整箱4斤包邮2kg',4,11,GETUTCDATE(),'两年',200,'待定项','山核桃拍原味，混合口味拍综合口味 混合是三个口味混装    整箱4斤包邮【偏远地区除外】，具体口味请在订单备注，默认随随机  可选口味：芝麻、花生、核桃',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(60,'琥珀牛羊配25g*40袋五香辣味膨化食品休闲小吃儿时怀旧零食大礼包',4,11,GETUTCDATE(),'两年',200,'待定项','小时候的味道，怀旧零食!20包 、40包 两种规格可选',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(61,'无糖肉松饼木糖醇糖尿饼病人无糖食品糖尿人病人零食孕妇糕点蛋糕',4,11,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(62,'上好佳鲜虾片薯片小吃膨化零食品店好吃的的批发大礼包送女友组合',4,11,GETUTCDATE(),'两年',200,'待定项','新旧包装随机发',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(63,'锅巴休闲特产零食粗粮锅巴原味香辣特产零食童年怀旧食品500g包邮',4,11,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(64,'三角结婚庆喜糖果好彩头小样Q酸QQ软糖散装500g85个零食品批发',4,11,GETUTCDATE(),'两年',200,'/Content/img/product/QQ软糖.jpg','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(65,'辈儿香 麻辣鱼味卷不是辣条油炸普通型膨化食品脆卷 56g*20袋包邮',4,11,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(66,'绝艺脆骨大辣味咔咔脆骨麻辣香辣猪软骨湖南特产办公室年货零食品',4,11,GETUTCDATE(),'两年',200,'待定项','该绝艺盒装咔咔脆骨有两个味道：1、大辣味（原麻辣味）2、甜辣味（微辣微甜）',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(67,'步步升南京板鸭26g*40袋办公室小吃膨化食品经典80后儿童怀旧零食',4,11,GETUTCDATE(),'两年',200,'待定项','规格：26g*40袋',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(68,'米多奇烤馍片整箱2kg早餐零食品清真烤香馍片饼干粗粮馒头片2000g',4,11,GETUTCDATE(),'两年',200,'待定项','本品是独立小包装，一包3片装60包约4斤， 一包6片装30包约4斤，是按亲们拍下的链接发货的。不指定口味， 本品属于易碎品，是用我们自己的纸箱封装的， 快递运输难免会有摔打挤压 ，我们没办法保证 不破碎，介意的亲们 还请慎拍 不足之处还请见谅！',1);
                    --文具图书
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(69,'三年二班Z可爱图书阅读记录卡 读书感想摘记本 学生笔记本子文具',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(70,'学生宿舍桌上书架简易伸缩桌面书籍文具收纳架置物架小型办公书柜',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(71,'办公小中大号书立学生铁书架书夹书靠图书馆档板阅读书架书隔文具',7,12,GETUTCDATE(),'两年',200,'待定项','此价格为1对的价格，批发价格不议价，办公学生学校用图书馆书店用书夹',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(72,'创意文具 学生专用读书笔记本 文章书籍记录本 车线软抄本 大 16K',7,12,GETUTCDATE(),'两年',200,'待定项','本本采用车线装订，可摊平，不掉页； 内页采用80g书写纸，白色纸张，绿色线条印刷； 专业设计的适合读书相关笔记的本本，比一般全横线的更好用； 一本可记39本书箱或文章的相关笔记，两个系列可选，规格，页数都一样就是封面不同。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(73,'特价资料夹办公文具实木信件收纳柜子书籍杂志报刊架 文件夹 抽屉',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(74,'木质货架书柜木质图书展示架绘本货架展示架专业文具展柜儿童书柜',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(75,'儿童阶梯涂色画幼儿宝宝画画启蒙 亲子学习绘画入门书籍文具用品',7,12,GETUTCDATE(),'两年',200,'待定项','每一幅都有涂色步骤，参考图以及绘画提示，可用蜡笔、水彩笔、彩铅、颜料等涂色。',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(76,'免订宿舍墙上粘贴置物架收纳架寝室床头放文具书籍手机粘墙壁挂架',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(77,'韩国文具得力打孔机单孔打洞器打孔器 自制图书工具 不织布打孔器',7,12,GETUTCDATE(),'两年',200,'待定项','',1);
                    INSERT INTO dbo.Product(Id, ProductName,CategoryId,ProviderId,ProductionDATE,KeepDate,Price,Url,Description,IsOnSale) 
                    VALUES(78,'悟生学生文具课桌神器书箱书籍多层挂式书挂袋桌面收纳盒收纳挂袋',7,12,GETUTCDATE(),'两年',200,'待定项','双杯款，带水袋、带笔袋，9大格+2小格，可容纳40本书，承重50kg，环保牛津布制作，学习家用收纳好帮手，课桌上的神器！',1);
                    ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Product");
        }
    }
}
