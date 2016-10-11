using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class exhibition : MonoBehaviour {
	public GameObject title;
	//public GameObject description;

	// Use this for initialization
	IEnumerator Start() {
		string url = string.Concat("http://140.117.71.205/exvisition/exhibition.php?eid=", init.eid);
		print(url);
		WWW www = new WWW(url);
		yield return www;

		string[] exhibition;
		exhibition = www.text.Split(';');
		title.GetComponent<Text>().text = exhibition[0];
		//description.GetComponent<Text>().text = exhibition[1];
	}
}