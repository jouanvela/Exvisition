using UnityEngine;
using System.Collections;

public class change : MonoBehaviour {


    void Awake()

    {

      
        Screen.orientation = ScreenOrientation.LandscapeRight;

    }




void Start()

    {
       
        Screen.orientation = ScreenOrientation.AutoRotation;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;

    }
}
