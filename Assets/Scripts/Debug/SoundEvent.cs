using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string[] EventSound;

    void PlaySound(FMOD.Studio.EventInstance EventSound)
    {
        if (EventSound.isValid())
        {
            EventSound.start(); 
        }
        else
        {
            Debug.LogError("EventSound is null");
        }

    }
}