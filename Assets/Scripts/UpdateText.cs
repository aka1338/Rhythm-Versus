using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text beat, marker, position, positionInSeconds;

    void Update()
    {
        beat.SetText("Beat: " + BeatSystem.beat);
        marker.SetText("Marker: " + BeatSystem.marker);
        position.SetText("Position: " + BeatSystem.timelinePosition);
        positionInSeconds.SetText("Position (Seconds): " + BeatSystem.time); 
    }
}
