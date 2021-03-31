using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSample : MonoBehaviour
{
    public Transform prefab;
    public static float animationDuration; 
    // Start is called before the first frame update
    void Start()
    {
        BeatSystem.OnBeat += SpawnNote; 
    }



    private void OnDisable()
    {
        BeatSystem.OnBeat -= SpawnNote;
    }

    private void SpawnNote()
    {
        animationDuration = BeatSystem.secPerBeat; 
        Instantiate(prefab, new Vector3(-9, 0, 0), Quaternion.identity);
    }



  
}
