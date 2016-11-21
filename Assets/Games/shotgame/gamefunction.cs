using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gamefunction : MonoBehaviour {
	public GameObject enemy;
	public float enemytime;

	public Text scoretext;
	public int score = 0;

	public static gamefunction Instance;

	public GameObject gametitle;
	public GameObject gameovertitle;
	public GameObject playbutton;
	public bool isplaying = false;

	public GameObject restartbutton;
	public GameObject quitbutton;

	/*auto bullet*/
	public float BulletTime;
	public GameObject fighter;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		Instance = this;

		gameovertitle.SetActive (false);

		restartbutton.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		enemytime += Time.deltaTime;
		if (enemytime > 1f && isplaying == true) {
			Vector3 pos = new Vector3 (Random.Range (-2.5f, 2.5f), 4.5f, 0);
			Instantiate (enemy, pos, gameObject.transform.rotation);
			enemytime = 0f;
		}

		BulletTime += Time.deltaTime;

		if(BulletTime > 0.3f && isplaying == true) {
			Vector3 bullet_pos = fighter.transform.position + new Vector3(0, 0.6f, 0);
			Instantiate(bullet, bullet_pos, fighter.transform.rotation);
			BulletTime = 0f;
		}
	
	}

	public void Addscore() {
		score += 10;
		scoretext.text = "Score : " + score;
	}

	public void GameStart() {
		isplaying = true;
		gametitle.SetActive (false);
		playbutton.SetActive (false);
		quitbutton.SetActive (false);
	}

	public void GameOver() {
		isplaying = false;
		gameovertitle.SetActive (true);
		restartbutton.SetActive (true);
		quitbutton.SetActive (true);
	}

	public void ResetGame() {
		SceneManager.LoadScene("1_Home");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
