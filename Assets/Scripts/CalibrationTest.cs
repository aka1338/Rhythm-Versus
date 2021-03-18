using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationTest : MonoBehaviour
{
    private float[] playerHits = new float[31];

    private float keyDownTime;
    public static float offset = 0;
    public static float calculation = 0;
    private int i = 0;

    private void Start()
    {
        for (int i = 0; i < playerHits.Length; i++)
        {
            playerHits[i]= 0;
        }
    }
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            keyDownTime = BeatSystem.timelinePosition;
            Debug.Log("F Pressed at " + keyDownTime + "  " + "Current markerTime: " + BeatSystem.markerTime);

           
            playerHits[i] = keyDownTime - BeatSystem.markerTime;
            calculation = playerHits[i]; 
            i++;
           
            calculateAudioLatency(); 
            
        }

    }

    private void calculateAudioLatency() {
        if (i >= 31) {
            for (int j = 0; j < playerHits.Length; j++) {
                offset += playerHits[j]; 
            }
            offset /= playerHits.Length;
            Debug.Log("The player audio offset is: " + offset);
        }
    }

}
