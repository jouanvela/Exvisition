using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class init : MonoBehaviour {
	
	public GameObject exploreBtn;

	public static string[] membersList;
	public static string eid = "1";
	public static string mid = "1";
	public static string iid = "1";
	public static string mode = "http://140.117.71.205/exvisition";

	void Awake(){
		Caching.CleanCache();
		Directory.CreateDirectory(Application.temporaryCachePath + "/audio/");
		Directory.CreateDirectory(Application.temporaryCachePath + "/video/");
		Directory.CreateDirectory(Application.temporaryCachePath + "/member/");

	}
	IEnumerator Start() {
		string path;
		string url;

		//Member List, and their Logo
		url = string.Concat(mode, "/listMember.php");
		WWW www = new WWW(url);
		yield return www;
		membersList = www.text.Split(';');
		for (int i = 0; i < membersList.Length - 1; i++) {
			path = Application.temporaryCachePath + "/member/" + membersList[i] + ".png";
			if (!File.Exists (path)) {
				url = string.Concat(mode,"/img/member/", membersList[i], ".png");
				www = new WWW (url);
				yield return www;
				File.WriteAllBytes (path, www.bytes);
			}
		}
		exploreBtn.SetActive(true);
	}
}