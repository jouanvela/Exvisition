using UnityEngine;
using System.Collections;

public class CheckWin : MonoBehaviour {

    public GameObject youWin;
    public check check;
    void Start() { }
    void Update()
    {
        CheckGameOver();
    }

    void CheckGameOver()
    {
        if (check.count == 9)
        {
            youWin.SetActive(true);
        }
       
    }
}
