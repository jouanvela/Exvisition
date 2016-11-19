using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menubehaviour : MonoBehaviour {
	public void triggermenubehaviour(int i) {
		switch (i) {
		default:
		case(0):
			SceneManager.LoadScene ("level");
			break;
		case(1):
			Application.Quit ();
			break;
		}
	}
}
