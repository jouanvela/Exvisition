using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movePiece : MonoBehaviour {

	public string pieceStatus="idle";
    Vector2 mousePosition;
	
	// Update is called once per frame
	void Update () {
        if (pieceStatus == "picked"){
            //Debug.Log(Input.mousePosition);
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == gameObject.name){
		    other.GetComponent<BoxCollider2D>().enabled = false;
		    GetComponent<BoxCollider2D>().enabled = false;
		    transform.position = other.gameObject.transform.position;
		    pieceStatus = "locked";
		    check.count++;

			SaveInfo ();
		}
    }
    void OnMouseDown(){
        pieceStatus = "picked";
    }

	private void SaveInfo(){
		Dictionary<string, bool[]> id = treasure.Treasure[treasure.NowChoice] as Dictionary<string, bool[]>;

		bool[] finished = id["finish"];

		switch(gameObject.name){
			case "A1":
				finished[0] = true;
				break;
			case "A2":
				finished[1] = true;
				break;
			case "A3":
				finished[2] = true;
				break;
			case "B1":
				finished[3] = true;
				break;
			case "B2":
				finished[4] = true;
				break;
			case "B3":
				finished[5] = true;
				break;
			case "C1":
				finished[6] = true;
				break;
			case "C2":
				finished[7] = true;
				break;
			case "C3":
				finished[8] = true;
				break;
		}

		id ["finish"] = finished;
		treasure.Treasure [treasure.NowChoice] = id;
	}
}