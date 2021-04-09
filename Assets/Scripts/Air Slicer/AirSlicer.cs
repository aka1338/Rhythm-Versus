using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlicer : MonoBehaviour
{
    public Transform prefab;
    public static float animationDuration;

    [FMODUnity.EventRef]
    public string sfx;

    void Start()
    {
        BeatSystem.OnMarker += SpawnNote;
        InputController.ActionOnePressed += PlaySwish;
    }

    private void OnDisable()
    {
        BeatSystem.OnMarker -= SpawnNote;
        InputController.ActionOnePressed -= PlaySwish;
    }

    private void SpawnNote()
    {
        //if (BeatSystem.marker.Substring(0, 5).Equals("note-")) 
        //{ 
        animationDuration = BeatSystem.secPerBeat;
        Instantiate(prefab, new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
        //}
    }

    private void PlaySwish()
    {
        Conductor.PlaySFX(sfx);
    }
}
