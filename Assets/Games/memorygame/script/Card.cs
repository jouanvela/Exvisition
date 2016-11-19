using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {
	public static bool do_not = false;

	[SerializeField]
	private int state;
	[SerializeField]
	private int cardvalue;
	[SerializeField]
	private bool initialized = false;

	private Sprite cardback;
	private Sprite cardface;

	private GameObject manager;

	void Start() {
		state = 1;
		manager = GameObject.FindGameObjectWithTag("Manager");
	}

	public void setupGraphics() {
		
		cardback = manager.GetComponent<GameManager> ().getCardBack ();
		cardface = manager.GetComponent<GameManager> ().getCardFace (cardvalue);

		flipcard ();
	}

	public void flipcard() {

		if (state == 0)
			state = 1;
		else if (state == 1)
			state = 0;

		if (state == 0 && !do_not)
			GetComponent<Image> ().sprite = cardback;
		else if (state == 1 && !do_not)
			GetComponent<Image> ().sprite = cardface;
	}

	public int cardValue {
		get { return cardvalue; }
		set { cardvalue = value; }
	}

	public int states {
		get { return state; }
		set { state = value; }
	}

	public bool initializedmethod {
		get { return initialized; }
		set { initialized = value; }
	}

	public void falseCheck() {
		StartCoroutine (pause ());
	}

	IEnumerator pause() {
		yield return new WaitForSeconds (1);
		if (state == 0)
			GetComponent<Image> ().sprite = cardback;
		else if (state == 1)
			GetComponent<Image> ().sprite = cardface;
		do_not = false;
	}
}
