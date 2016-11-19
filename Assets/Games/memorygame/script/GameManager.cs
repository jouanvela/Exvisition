using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text matchText;

	private bool init = false;
	private int matches = 8;
		
	// Update is called once per frame
	void Update () {
		if (!init)
			initializeCards ();

		if (Input.GetMouseButtonUp (0))
			checkCards ();
	}

	void initializeCards() {
		for (int id = 0; id < 2; id++) {
			for (int i = 1; i < 9; i++) {

				bool test = false;
				int choice = 0;
				while (!test) {
					choice = Random.Range (0, cards.Length);
					test = !(cards [choice].GetComponent<Card> ().initializedmethod);

				}
				cards [choice].GetComponent<Card> ().cardValue = i;
				cards [choice].GetComponent<Card> ().initializedmethod = true;
			}
		}

		foreach (GameObject c in cards)
			c.GetComponent<Card> ().setupGraphics ();

		if (!init)
			init = true;
	}

	public Sprite getCardBack() {
		return cardBack;
	}

	public Sprite getCardFace(int i) {
		return cardFace [i - 1];
	}

	void checkCards() {
		List<int> c = new List <int> ();

		for (int i = 0; i < cards.Length; i++) {
			if (cards [i].GetComponent<Card> ().states == 1)
				c.Add (i);
		}

		if (c.Count == 2)
			cardComparison (c);
	}

	void cardComparison(List<int> c) {
		Card.do_not = true;

		int x = 0;

		if (cards [c [0]].GetComponent<Card> ().cardValue == cards [c [1]].GetComponent<Card> ().cardValue) {
			x = 2;
			matches--;
			matchText.text = "Number of Matches : " + matches;
			if (matches == 0)
				SceneManager.LoadScene ("menu");
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<Card> ().states = x;
			cards [c [i]].GetComponent<Card> ().falseCheck ();
		}
	}
}
