<?php

	include("db.php");

    $SQL = 'SELECT * FROM `member` WHERE 1 ORDER BY mid';
    $stmt = $dbh->prepare("$SQL");
    $stmt->execute();

    $a = array();

    while ($rs = $stmt->fetch(PDO::FETCH_OBJ)) {
        $mid        = $rs->mid;
        $mName		= $rs->mName;
        $pwd		= $rs->pwd;
        array_push($a, array($mid => $mName));
        //echo $mid.";";
    }

    echo json_encode($a, JSON_UNESCAPED_UNICODE);
?>
