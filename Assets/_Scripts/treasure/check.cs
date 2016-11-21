using UnityEngine;
using System.Collections;

public class check : MonoBehaviour {
	
    public GameObject finish;
    public static int count = 0;

	void Update(){
		CheckGameOver();
	}

    void CheckGameOver(){
        if (count==9){
			finish.SetActive(true);
        }
    }
}