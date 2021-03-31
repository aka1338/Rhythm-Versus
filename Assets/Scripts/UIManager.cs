using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum Screens 
    {
        Pause = 1,
        Game
    }
    // This class should contain enums on the types of screens the player is able to view.
    // The UI itself should have OnClick() events that point to the GameManager and pass the Minigame Enum that is selected to be played. 

    public static void SwitchScreen(Screens screen)
    {
        if (screen == Screens.Pause)
        {
            Debug.Log("The game is paused.");
        }
        else if (screen == Screens.Game) {
            Debug.Log("The game is now unpaused"); 
        }
    }

}
