<?php

    include("db.php");

    $mid = $_POST['mid'];

    $SQL = 'SELECT * FROM `exhibition` WHERE mid = '.$mid;
    $stmt = $dbh->prepare("$SQL");
    $stmt->execute();

    //$a = array();

    while ($rs = $stmt->fetch(PDO::FETCH_OBJ)) {
        $mid        = $rs->mid;
        $eid        = $rs->eid;
        $eName      = $rs->eName;
        //array_push($a, array($mid => $mName));
        echo $eName.";";
    }

    //echo json_encode($a, JSON_UNESCAPED_UNICODE);
?>
