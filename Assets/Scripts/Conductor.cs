using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // This class should handle song event instances in order to grab timeline data. There can only be one instance of a song tied to the BeatSystem at a time.
    // This class dictates whatever should be playing at whatever time, reguardless of it being a one shot, minigame/menu music, or ambient noise. 
    // What this means is that NO OTHER CLASS should ever be calling an FMOD EventInstance using .start().  

    // TODO: Function PlayOneShot(), Handling of one shot noises (that don't need to be tied to the BeatSystem)
    // TODO: When a minigame is chosen, the Minigame itself should send this class an array of every FMOD event required for that minigame, which will be stored during runtime. 
   
    
    private static FMOD.Studio.EventInstance _instance;
    private static BeatSystem bS;

    // Start is called before the first frame update
    // Grabs the BeatSystem component attached to the GameObject. Must have a BeatSystem attached to the same object for Conductor to correctly function.
    // TODO: Error checking to ensure that the BeatSystem is attached to the same GameObject the Conductor is. 
    void Start()
    {
        bS = GetComponent<BeatSystem>();
    }

    // Creates an FMOD instance of a minigame song. Note that this function should take in a minigame song meant to be used with the BeatSystem. 
    public static void CreateBeatInstance(string minigameSong)  
    {
        _instance = FMODUnity.RuntimeManager.CreateInstance(minigameSong);
    }
    
    // Starts minigame music. I should probably rename this to StartMinigameMusic() to be more clear that this is ONLY meant to be used with BeatSystem attached music.  
    public static void StartMusic()
    {
        _instance.start();
        bS.AssignBeatEvent(_instance);
    }

    // Stops the BeatSystem event from playing. Should also be renamed to reflect this.  
    public static void StopAndClear() 
    {
        bS.StopAndClear(_instance);
    }

    // TODO: This pause function should actually pause every sound event currently playing, and not just the BeatSystem. 
    public static void PauseMusic() 
    {
        bS.Pause(_instance); 
    }

    //TODO: Same as above function (should resume every sound event currently playing). 
    public static void ResumeMusic() 
    {
        bS.Resume(_instance); 
    }
}
