using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject explode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (0, -0.01f, 0);
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "fighter"||col.tag == "Bullet"){
			Destroy (col.gameObject);
			Destroy (gameObject);

			Instantiate (explode, transform.position, transform.rotation);

			if (col.tag == "fighter") {
				Instantiate (explode, col.gameObject.transform.position, col.gameObject.transform.rotation);

				gamefunction.Instance.GameOver ();
			}

			gamefunction.Instance.Addscore ();
		}
	}
}
