using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
public class JSONTest : MonoBehaviour {
	private string jsonString;
	private JsonData jsonData;
	IEnumerator Start () {
		WWW www = new WWW("http://127.0.0.1/exvisition/listMember.php");
		yield return www;
		jsonString = www.text;
		//jsonString = File.ReadAllText (Application.dataPath + "/sample.json");
		jsonData = JsonMapper.ToObject (jsonString);
		Debug.Log (jsonData["mid"]);
		//Debug.Log (jsonData["name"]);
		//Debug.Log (jsonData["age"]);
		//Debug.Log (jsonData["item_bag"][0]["name"] + ":" + jsonData["item_bag"][0]["price"]);
		//Debug.Log (jsonData["item_bag"][1]["name"] + ":" + jsonData["item_bag"][1]["price"]);
		//Debug.Log (jsonData["item_bag"][2]);
	}
}