using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class exhibition : MonoBehaviour {
	public GameObject title;
	//public GameObject description;

	// Use this for initialization
	IEnumerator Start() {
		string url = string.Concat("http://140.117.71.205/exvisition/exhibition.php?eid=", init.eid);
		WWW www = new WWW(url);
		yield return www;

		string path = Application.temporaryCachePath + "/exhibition/" + init.eid;
		if(!File.Exists(path))
			Directory.CreateDirectory(path);

		string[] exhibition;
		exhibition = www.text.Split(';');
		title.GetComponent<Text>().text = exhibition[0];
		//description.GetComponent<Text>().text = exhibition[1];
	}
}