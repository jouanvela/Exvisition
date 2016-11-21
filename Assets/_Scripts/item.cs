using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class item : MonoBehaviour {
	public GameObject title;
	public GameObject description;
	public GameObject picture;
	public GameObject audioBtn;
	public GameObject videoBtn;
	public GameObject gameBtn;
	public AudioSource audioSource;

	// Use this for initialization
	IEnumerator Start() {
		string url;
		string path;
		string[] item; //DataFromDB
		WWW www;

		//Load Database
		url = string.Concat(init.mode,"/item.php?iid=", init.iid);
		www = new WWW(url);
		yield return www;
		if(www.text=="Error")
			SceneManager.LoadScene("4_Select_Exhibition");
		item = www.text.Split(';');
		title.GetComponent<Text>().text = item[0];
		description.GetComponent<Text>().text = item[1];

		//Load Picture
		if(item[2] == "1"){
			path = Application.temporaryCachePath + "/exhibition/" + init.eid + "/" + init.iid + ".jpg";
			if (!File.Exists (path)) {
				url = string.Concat(init.mode,"/img/", init.eid, "/", init.iid, ".jpg");
				www = new WWW (url);
				yield return www;
				File.WriteAllBytes (path, www.bytes);
			} 
			else {
				url = string.Concat("file://" + path);
				www = new WWW(url);
				yield return www;
			}
			Sprite s = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
			picture.GetComponent<Image>().sprite = s;
		}

		//Load Audio
		if(item[3] == "1"){
			path = Application.temporaryCachePath + "/audio/" + init.iid + ".mp3";
			if (!File.Exists (path)) {
				url = string.Concat(init.mode,"/audio/", init.iid, ".mp3");
				www = new WWW (url);
				yield return www;
				File.WriteAllBytes (path, www.bytes);
			} 
			else {
				url = string.Concat("file://" + path);
				www = new WWW(url);
				yield return www;
			}
			audioSource = audioSource.GetComponent<AudioSource>();
			audioSource.clip = www.audioClip;
			audioBtn.GetComponent<Button>().image.color = Color.red;
			audioBtn.GetComponent<Button>().onClick.AddListener(() => {
				playaudio();
			});
		}

		//Load Video
		if (item [4] == "1") {			
			path = Application.temporaryCachePath + "/video/" + init.iid + ".mp4";
			if (!File.Exists (path)) {
				url = string.Concat (init.mode,"/video/", init.iid, ".mp4");
				www = new WWW (url);
				yield return www;
				File.WriteAllBytes (path, www.bytes);
			}
			videoBtn.GetComponent<Button> ().image.color = Color.green;
			videoBtn.GetComponent<Button> ().onClick.AddListener (() => {
				StartCoroutine (playvideo (path));
			});
		}
	}

	void playaudio() {
		if (!audioSource.isPlaying && (audioSource.clip.loadState == AudioDataLoadState.Loaded))
			audioSource.Play ();
		else
			audioSource.Stop();
	}

	IEnumerator playvideo(string path) {
		Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.Full);
		yield return new WaitForEndOfFrame();
	}
}