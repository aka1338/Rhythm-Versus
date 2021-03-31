using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO: Events that fire off based on how well timed a player's input was checked against the BeatSystem. 
    //The events are: PerfectHit, EarlyHit, LateHit, and Missed.  

    // This class should only be responsible for firing off events to other classes, as well as handling things that have to do with gamestate. 
    // F.e., if the UI needs to know when a note has been successfully hit, they can subscribe to the events denoted within this class.  

    // This class is also in charge of telling the Player.cs script when a point needs to be added to which Player ID. 

    public static float keyDownTime;

    // Should be set to a PlayerPref. For now, adjust in editor. 
    public static float offset;

    public delegate void NoteTiming();
    public static event NoteTiming ValidHit;
    public static event NoteTiming EarlyHit;
    public static event NoteTiming LateHit;


    private void Start()
    {
        InputController.ActionOnePressed += CheckForValidHit;
        InputController.ActionTwoPressed += CheckForValidHit;
        InputController.pausePressed += PauseMenu; 
    }

    private void OnDisable()
    {
        InputController.ActionOnePressed -= CheckForValidHit;
        InputController.ActionTwoPressed -= CheckForValidHit;
        InputController.pausePressed -= PauseMenu;
    }

    public void CheckForValidHit()
    {
        Debug.Log("Checking for valid hit");
        keyDownTime = BeatSystem.timelinePosition;
        Debug.Log("F Pressed at " + keyDownTime + "  " + "Current markerTime: " + BeatSystem.markerTimeLinePosition);

        if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0) 
        {
            ValidHit?.Invoke(); 
        }
    }

    public void PauseMenu()
    {
        Debug.Log("Opened a pause menu.");
    }
}
