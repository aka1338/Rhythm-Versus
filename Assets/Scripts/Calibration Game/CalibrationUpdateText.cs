using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalibrationUpdateText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text markerTime, playerHit, average, difference; 

    void Update()
    {
        markerTime.SetText("Marker Time: " + BeatSystem.markerTimeLinePosition + "ms");
       
        
        average.SetText("Audio Latency: " + GameManager.offset + "ms");
        difference.SetText("Calculated Difference: " + (GameManager.keyDownTime) + "ms");
    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            playerHit.SetText("Hit detected at: " + BeatSystem.timelinePosition + "ms" );

        }

    }
}
