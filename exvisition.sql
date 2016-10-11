-- --------------------------------------------------------
-- 主機:                           127.0.0.1
-- 服務器版本:                        10.1.16-MariaDB - mariadb.org binary distribution
-- 服務器操作系統:                      Win64
-- HeidiSQL 版本:                  9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 導出 exvisition 的資料庫結構
CREATE DATABASE IF NOT EXISTS `exvisition` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `exvisition`;


-- 導出  表 exvisition.exhibition 結構
CREATE TABLE IF NOT EXISTS `exhibition` (
  `mid` int(10) unsigned NOT NULL COMMENT '會員(展館)編號',
  `eid` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '展覽編號',
  `eName` varchar(255) NOT NULL COMMENT '展覽名稱',
  `eDescription` text COMMENT '展覽簡介',
  `eStartTime` date DEFAULT NULL COMMENT '展覽起始日',
  `eEndTime` date DEFAULT NULL COMMENT '展覽結束日',
  PRIMARY KEY (`eid`,`mid`),
  KEY `eid` (`eid`),
  KEY `mid` (`mid`),
  CONSTRAINT `exhibition_ibfk_1` FOREIGN KEY (`mid`) REFERENCES `member` (`mid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 正在導出表  exvisition.exhibition 的資料：~3 rows (大約)
/*!40000 ALTER TABLE `exhibition` DISABLE KEYS */;
INSERT INTO `exhibition` (`mid`, `eid`, `eName`, `eDescription`, `eStartTime`, `eEndTime`) VALUES
	(1, 1, '搖擺吧！動物們 - 藝術設計展', '來自7個國家、23組國內外藝術家和設計師，以「動物」為主題進行創作，「蟲、魚、鳥、獸」四大主題突顯不同生活環境下的動物特性，彷彿為動物們舉辦一場嘉年華會，讓動物議題活絡起來，成為主角，開始搖擺！', '2016-01-27', '2016-08-31'),
	(2, 2, '顛倒屋特展 高雄站', '《顛倒屋特展》百分之百獨家打造六大主題：倒立顛倒屋、變形哈哈屋、歡樂遊戲樹屋、可愛蘑菇屋與神祕小矮人屋！顛倒屋：180度大翻轉！挑戰科學極限！六大互動主題展覽玩樂雙重體驗！令人眼花撩亂的視覺特效，結合藝術、科技、玩樂及無限想像力，保證讓你驚嘆連連，怎麼玩都不會膩！', '2016-06-15', '2016-08-28'),
	(3, 3, '藝術~咔滋咔滋 Art, Yummy!', '我們每天都要吃，食物讓我們成長，提供生命的能量。可是，你知道餐桌上食物的本來長相？認識食物的色彩及對身體的重要嗎？<br><br>台灣可以吃到各個國家的料理，但你知道有些食物，很久很久以前是翻山越嶺、飄洋過海才抵達的嗎？比如，400年前的台灣，你吃不到鳳梨、香蕉、西瓜；100年前，蘋果、柳丁、草莓還沒落地生根。如果不小心回到從前，可別吵著吃！<br><br>在藝術家眼中，食物常是創作靈感來源，藝術家運用他們的創造力：蛋糕甜點是生活中的幸福、水餃是思念家鄉的記憶、巧克力變成戰爭遊戲……它們都不只是好滋味的食物。藝術家的想像力，究竟是怎麼一回事？<br><br>芝麻，開門！探頭瞧瞧「藝術~咔滋咔滋」展，你將發現圍繞食物與藝術的故事，神奇又有趣。來吧！一起探索一顆番薯，兩顆地瓜。咦？', '2016-07-03', '2017-11-04'),
  (1, 4, '生命的壯闊：演化之旅', '地球至今46億年，累積了35億年生命的演化，在歷經了多次生物滅絕事件、環境變遷及長時間推演考驗中，終於交織出璀璨萬物。', NULL, NULL),
  (1, 5, '承先啟後：羅丹與他的藝術圈', '19世紀的法國巴黎是現代藝術發展蓬勃之地，羅丹站在傳統與現代的分水嶺上，有著傳統技法的厚實訓練和永不枯竭的創造力。羅丹是繼米開蘭基羅後，被討論最多也最廣的雕塑家，更是偉大傳統的最終樂章。本展試圖對這位藝術史上的巨擘提出新的書寫脈絡，探索他所處的時代背景與藝術環境，早期老師對他創作的影響，同儕的競爭與合作關係以及羅丹對後輩雕塑家產生的影響力。', NULL, NULL),
  (3, 6, '植物新樂園', '植物在哪裡?在山林、田野、海邊、池塘、公園或路旁，我們都不難看見它們的身影，但是你可曾留意它們在不同季節裡的變化?兒美館新展「植物新樂園」邀請了八位藝術家參與創作，同時結合館藏作品與園區植物觀察，展現植物的不同面向，透過作品延伸的互動展示教具，不僅提供孩子從生活學習觀察與記錄，同時也藉由記錄片與繪本，讓孩子感受人與自然和諧共存的關係。', '2016-01-31', '2017-05-31');

/*!40000 ALTER TABLE `exhibition` ENABLE KEYS */;


-- 導出  表 exvisition.item 結構
CREATE TABLE IF NOT EXISTS `item` (
  `eid` int(10) unsigned NOT NULL COMMENT '展覽編號',
  `iid` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '展品編號',
  `iName` varchar(255) NOT NULL COMMENT '展品名稱',
  `iDescription` text COMMENT '展品簡介',
  `game` varchar(255) DEFAULT NULL COMMENT '對應遊戲',
  PRIMARY KEY (`eid`,`iid`),
  KEY `iid` (`iid`),
  CONSTRAINT `item_ibfk_1` FOREIGN KEY (`eid`) REFERENCES `exhibition` (`eid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在導出表  exvisition.item 的資料：~0 rows (大約)
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;


-- 導出  表 exvisition.member 結構
CREATE TABLE IF NOT EXISTS `member` (
  `mid` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '會員(展館)編號',
  `mName` varchar(255) NOT NULL COMMENT '會員(展館)名稱',
  `pwd` varchar(255) NOT NULL COMMENT '網頁登入密碼',
  `mDescription` text COMMENT '會員(展館)簡介',
  PRIMARY KEY (`mid`),
  KEY `mid` (`mid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 正在導出表  exvisition.member 的資料：~3 rows (大約)
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` (`mid`, `mName`, `pwd`, `mDescription`) VALUES
	(1, '奇美博物館', '0000', '奇美博物館是奇美集團創辦人許文龍先生，從孩提到年老、跨越八十年的圓夢故事。<br>許創辦人年幼時經常到臺南州立教育博物館參觀，小小年紀的他深受感動，便在心底埋下一顆文化種子，希望將來能夠建造一座為大眾而設的博物館，讓民眾可以當成自己的家，隨時回家來享受心靈饗宴。在塑膠材料事業發展穩定後，他先以私人之力進行蒐藏，之後成立基金會，並在奇美實業支持下，於1992年創立奇美博物館，於奇美實業仁德廠內免費對外營運二十餘年。為了完整呈現奇美典藏，歷經十多年努力終於覓得新址，建造了一座西洋美學風格的建築，亦即現在的博物館樣貌。許創辦人發願：這座博物館將永遠為大眾而存在。'),
	(2, '國立科學工藝博物館', '0000', '國立科學工藝博物館為國立社會教育機構，以推廣社會科技教育為其主要功能，故其建館任務為研究、設計、展示各項科技主題，引介重要科技之發展及其對人類生活的影響。'),
	(3, '高雄市立美術館', '0000', '20歲的高美館：有情‧有感‧有美');
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
