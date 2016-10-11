using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class init : MonoBehaviour {
	
	public GameObject exploreBtn;

	public static string eid = "1";
	public static string mid = "1";
	public static string iid = "1";

	void Awake(){
		Directory.CreateDirectory(Application.temporaryCachePath + "/audio/");
		Directory.CreateDirectory(Application.temporaryCachePath + "/video/");
		exploreBtn.SetActive(true);
	}
}