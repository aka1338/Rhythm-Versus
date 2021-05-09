using UnityEngine;

public class CalibrationTest : MonoBehaviour
{
    private float[] playerHits = new float[30];
    private int indexLength = 30;
    private int i = 0;
    public static float finalOffset;

    private void OnEnable()
    {
        InputController.ActionOnePressed += CalculateAudioLatency;
    }

    private void OnDisable()
    {
        InputController.ActionOnePressed += CalculateAudioLatency;
    }

    private void CalculateAudioLatency()
    {
        if (i < indexLength)
            playerHits[i] = BeatSystem.timelinePosition - BeatSystem.markerTimeLinePosition;

        i++;
        if (i >= indexLength)
        {
            for (int j = 0; j < indexLength; j++)
            {
                GameManager.offset += playerHits[j];
            }

            GameManager.offset /= indexLength;
            finalOffset = GameManager.offset;
        }
    }

}
