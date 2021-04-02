using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // This class should handle song event instances in order to grab timeline data. There can only be one instance of a song tied to the BeatSystem at a time.
    // TODO: Handling of one shot noises (that don't need to be tied to the BeatSystem)
    // This class dictates whatever should be playing at whatever time, reguardless of it being a one shot, minigame/menu music, or ambient noise.  

    private static FMOD.Studio.EventInstance _instance;
    private static BeatSystem bS;

    // Start is called before the first frame update
    void Start()
    {
        bS = GetComponent<BeatSystem>();
    }

    public static void CreateBeatInstance(string minigameSong)  
    {
        _instance = FMODUnity.RuntimeManager.CreateInstance(minigameSong);
    }

    public static void StartMusic()
    {
        _instance.start();
        bS.AssignBeatEvent(_instance);
    }

    public static void StopAndClear() 
    {
        bS.StopAndClear(_instance);
    }

    public static void PauseMusic() 
    {
        bS.Pause(_instance); 
    }

    public static void ResumeMusic() 
    {
        bS.Resume(_instance); 
    }
}
