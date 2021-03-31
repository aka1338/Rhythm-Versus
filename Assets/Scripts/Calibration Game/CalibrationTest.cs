using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationTest : MonoBehaviour
{
    private float[] playerHits = new float[30];
    private int indexLength = 30; 
    private float keyDownTime;
    public static float offset;
    public static float calculation;
    private int i = 0;

    //TODO: Store this inside of a PlayerPrefs variable, will permanately equal their offset value. 
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            keyDownTime = BeatSystem.timelinePosition;
            Debug.Log("F Pressed at " + keyDownTime + "  " + "Current markerTime: " + BeatSystem.markerTimeLinePosition);
            playerHits[i] = keyDownTime - BeatSystem.markerTimeLinePosition;
            calculation = playerHits[i];
            Debug.Log(calculation); 
            i++;
            calculateAudioLatency();      
        }

    }

    private void calculateAudioLatency() {
        if (i >= indexLength) {
            for (int j = 0; j < indexLength; j++) {
                offset += playerHits[j];
            }
            offset /= indexLength;
            Debug.Log("The player audio offset is: " + offset);
        }
    }

}
