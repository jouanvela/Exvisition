using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class check : MonoBehaviour {

	public GameObject[] puzzle;
	public GameObject[] trigger;
    public GameObject finish;
    public static int count = 0;

	void Start(){
		Dictionary<string, bool[]> id = treasure.Treasure[treasure.NowChoice] as Dictionary<string, bool[]>;

		bool[] able = id["have"];
		bool[] finished = id["finish"];

		for(int i = 0; i < able.Length; i++){
			if (!able [i])
				puzzle [i].SetActive (false);
			else if (finished [i]) {
				puzzle[i].transform.position = trigger[i].transform.position;
				puzzle[i].GetComponent<movePiece>().pieceStatus = "locked";
				count++;
			}
		}

	}

	void Update(){
		CheckGameOver();
	}

    void CheckGameOver(){
        if (count==9){
			finish.SetActive(true);
        }
    }
}