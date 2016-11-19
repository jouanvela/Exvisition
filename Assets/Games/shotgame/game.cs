using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	//public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*control for pc version
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.position += new Vector3 (0.1f, 0, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.position += new Vector3 (-0.1f, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0.6f, 0);
			Instantiate (Bullet, pos, gameObject.transform.rotation);
		}*/

		/*control for android version*/
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			gameObject.transform.Translate (new Vector3 (Input.touches [0].deltaPosition.x * Time.deltaTime,
											Input.touches [0].deltaPosition.y * Time.deltaTime, 0));
		}
	
	}
}

