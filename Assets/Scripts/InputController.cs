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
            Debug.Log("F Pressed at " + keyDownTime + "  " + "Current markerTime: " + BeatSystem.markerTimeLinePosition);

        }

        if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0)
        {
            Debug.Log("On time!");
        }
        else
        {
            Debug.Log("Off time!");
        }

    }
}
