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
        markerTime.SetText("Marker Time: " + BeatSystem.markerTime + "ms");
       
        
        average.SetText("Audio Latency: " + CalibrationTest.offset + "ms");
        difference.SetText("Calculated Difference: " + CalibrationTest.calculation + "ms");
    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            playerHit.SetText("Hit detected at: " + BeatSystem.timelinePosition + "ms" );

        }

    }
}
