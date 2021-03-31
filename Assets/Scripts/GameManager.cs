using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
