using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int score = 1;
    public bool isActive = false;

    public KeyCode actionOne;
    public KeyCode actionTwo;
    public KeyCode pause;

    // If the player is not active, a blank window with graphic will appear, and will not spawn a minigame prefab. 
    public void AddScore() 
    {
        score++;
    }



    // This script will house all the player's data, like their username, as well as their score during a minigame, and overall minigames won while playing in a lobby. 
    // Note that this is different from player persistent data, like options. 

}
