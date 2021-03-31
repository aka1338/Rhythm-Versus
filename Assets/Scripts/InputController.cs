using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float keyDownTime;
    public float offset; 
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            keyDownTime = BeatSystem.timelinePosition;
            Debug.Log("F Pressed at " + BeatSystem.timelinePosition + "  " + "Current markerTime: " + BeatSystem.markerTimeLinePosition + " With offset " + (offset + BeatSystem.markerTimeLinePosition));

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
}
