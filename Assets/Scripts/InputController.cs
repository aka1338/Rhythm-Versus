using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float keyDownTime;
    private float offset; 
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            keyDownTime = BeatSystem.time;
            Debug.Log("F Pressed at " + keyDownTime + "  " + "Current markerTime: " + BeatSystem.markerTime);

        }

        if (keyDownTime >= BeatSystem.markerTime - offset && keyDownTime <= BeatSystem.markerTime + offset && BeatSystem.markerTime != 0)
        {
            Debug.Log("On time!");
        }
        else
        {
            Debug.Log("Off time!");
        }

    }
}
