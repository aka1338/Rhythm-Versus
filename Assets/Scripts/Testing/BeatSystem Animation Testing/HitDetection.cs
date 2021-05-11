using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HitDetection : MonoBehaviour
{
    private float keyDownTime;
    public float offset;

    public Transform cubeTransform;
    public Material cubeMaterial;

    private FMOD.Studio.EventInstance animInstance;
    private BeatSystem animBS;

    private void Start()
    {
        animBS = GetComponent<BeatSystem>();
        animInstance = FMODUnity.RuntimeManager.CreateInstance("event:/animation");
        animBS.AssignBeatEvent(animInstance);
        animInstance.start();

    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("f")))
        {
            keyDownTime = BeatSystem.timelinePosition;
            Debug.Log("F Pressed at " + BeatSystem.timelinePosition + "  " + "Current markerTime: " + BeatSystem.markerTimeLinePosition + " With offset " + (offset + BeatSystem.markerTimeLinePosition));

            if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0)
            {
                Debug.Log("On time!");
                cubeMaterial.DOColor(Color.yellow, .2f);

            }
            else
            {
                Debug.Log("Off time!");
                cubeMaterial.DOColor(Color.red, .2f);

            }
        }



    }
}
