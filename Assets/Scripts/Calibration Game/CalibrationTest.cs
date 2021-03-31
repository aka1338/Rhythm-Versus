using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationTest : MonoBehaviour
{
    private float[] playerHits = new float[30];
    private int indexLength = 30; 
    private int i = 0;

    private void Start()
    {
        InputController.ActionOnePressed += CalculateAudioLatency;   
    }

    private void CalculateAudioLatency() {
        playerHits[i] = GameManager.keyDownTime - BeatSystem.markerTimeLinePosition;
        i++;
        if (i >= indexLength) {
            for (int j = 0; j < indexLength; j++) {
                GameManager.offset += playerHits[j];
            }
            
            GameManager.offset /= indexLength;
            Debug.Log("The player audio offset is: " + GameManager.offset);
        }
    }

}
