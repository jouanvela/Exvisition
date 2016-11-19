using UnityEngine;
using System.Collections;

public class Movepiece : MonoBehaviour {

    public string pieceStatus="idle";
    // Use this for initialization
    Vector2 mousePosition;
    public check check;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (pieceStatus == "picked")
        {
            //Debug.Log(Input.mousePosition);
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;

        }
        
            }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == gameObject.name){
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            check.count++;
                               }

    }
    void OnMouseDown()
    {
        pieceStatus = "picked";        
    
    }
    
    }
