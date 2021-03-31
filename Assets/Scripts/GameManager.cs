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
    }

    public void PauseMenu() 
    {
        Debug.Log("Opened a pause menu.");
    }
}
