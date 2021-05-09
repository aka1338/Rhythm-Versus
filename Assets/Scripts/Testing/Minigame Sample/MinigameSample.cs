using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSample : MonoBehaviour
{
    public Transform prefab;
    public Transform spawnPosition;

    public static float animationDuration;

    void Start()
    {
        BeatSystem.OnMarker += SpawnNote;
    }

    private void OnDisable()
    {
        BeatSystem.OnMarker -= SpawnNote;
    }

    private void SpawnNote()
    {
        //if (BeatSystem.marker.Substring(0, 5).Equals("note-")) 
        //{ 
            Instantiate(prefab);
            prefab.transform.position = new Vector3(spawnPosition.position.x - 9,0,0); 
            animationDuration = BeatSystem.secPerBeat;
        //}
    }

}
