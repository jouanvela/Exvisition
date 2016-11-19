using UnityEngine;
using System.Collections;

public class check : MonoBehaviour {

    
    public GameObject youWin;
    public int count = 0;

    void CheckGameOver()
    {
        if (count==9)
        {
          youWin.SetActive(true);
        }
    }
}
