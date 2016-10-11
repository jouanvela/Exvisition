using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class member : MonoBehaviour {
    public GameObject title;
    public GameObject description;

    // Use this for initialization
    IEnumerator Start() {
		string url = string.Concat("http://140.117.71.205/exvisition/member.php?mid=", init.mid);
        print(url);
        WWW www = new WWW(url);
        yield return www;

        string[] member;
		member = www.text.Split(';');
        title.GetComponent<Text>().text = member[0];
        description.GetComponent<Text>().text = member[1];
    }
}