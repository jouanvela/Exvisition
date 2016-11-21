using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class treasure : MonoBehaviour {

	public static string NowChoice = "E1";

	public static Dictionary<string, object> Treasure = new Dictionary<string, object>(){
		{"E1", new Dictionary<string, bool[]>(){
				{"have", new bool[9]{true, false, false, false, false, true, false, false, false}},
				{"finish", new bool[9]{true, false, false, false, false, false, false, false, false}}
			}
		},
		{"E2", new Dictionary<string, bool[]>(){
				{"have", new bool[9]{false, false, false, false, false, false, false, false, false}},
				{"finish", new bool[9]{false, false, false, false, false, false, false, false, false}}
			}
		}
	};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
