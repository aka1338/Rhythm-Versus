using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSample : MonoBehaviour
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
            Instantiate(prefab, new Vector3(-9, 0, 0), Quaternion.identity);
        //}
    }

    private void PlaySwish()
    {
        Conductor.PlaySFX(sfx); 
    }
}
