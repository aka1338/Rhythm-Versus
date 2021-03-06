﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private BeatSystem bS;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instance.start();
            bS.AssignBeatEvent(instance);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/music");
            instance.start();
            bS.AssignBeatEvent(instance);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bS.StopAndClear(instance);
        }
    }
}
