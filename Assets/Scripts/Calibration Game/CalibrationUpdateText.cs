using TMPro;
using UnityEngine;

public class CalibrationUpdateText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text markerTime, playerHit, difference, finalOffset;

    private void OnEnable()
    {
        //InputController.ActionOnePressed += UpdateText;
    }

    private void Start()
    {
        markerTime.SetText("Marker Time: " + 0 + "ms");
        difference.SetText("Calculated Difference: " + 0 + "ms");

    }

    void UpdateText()
    {
        markerTime.SetText("Marker Time: " + BeatSystem.markerTimeLinePosition + "ms");
        difference.SetText("Calculated Difference: " + (BeatSystem.timelinePosition - BeatSystem.markerTimeLinePosition) + "ms");
        playerHit.SetText("Hit detected at: " + BeatSystem.timelinePosition + "ms");

        // Unsubscribes from input events, so that text is not changed when the test has been completed. 
        if (CalibrationTest.finalOffset != 0f) 
        {
          //  InputController.ActionOnePressed += UpdateText;
        }
        finalOffset.SetText("Estimated Offset: " + CalibrationTest.finalOffset.ToString("F0") + "ms");
    }

}
