<?php

	//資料庫資訊
	$dbhost		='127.0.0.1';
	$dbname		='exvisition';
	$dbuser		='';
	$dbpassword	='';


	// 連接資料庫的的設定,預設將 set name utf8 開啟
	//

	try {
		// 在 PDO 宣告的時候就要將編碼一併宣告。 ref.pdo-mysql.connection
		global $dbh;
		$dsn = "mysql:host=$dbhost;dbname=$dbname";
		$options = array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8');
		$dbh = new PDO($dsn, $dbuser, $dbpassword, $options);



	} catch (PDOException $e) {
	    print "DB connect Error!: " . $e->getMessage() . "<br/>";
	    die();
	}
	date_default_timezone_set("Asia/Taipei");
?>
