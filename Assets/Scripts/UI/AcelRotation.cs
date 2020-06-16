using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.acceleration.y > 0.7f)
            Screen.orientation = ScreenOrientation.LandscapeRight;
        if (Input.acceleration.y < -0.7f)
            Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
