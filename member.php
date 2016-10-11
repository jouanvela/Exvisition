<?php

	include("db.php");

    $mid = $_GET["mid"];

    $SQL = 'SELECT * FROM `member` WHERE mid = '.$mid;
    $stmt = $dbh->prepare("$SQL");
    $stmt->execute();
    $rs = $stmt->fetch(PDO::FETCH_OBJ);

    $mid            = $rs->mid;
    $mName		    = $rs->mName;
    $mDescription   = $rs->mDescription;
    echo $mName.";".$mDescription;

?>
