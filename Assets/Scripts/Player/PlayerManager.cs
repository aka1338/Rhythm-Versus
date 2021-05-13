using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;

    public AirSlicer instance; 

    private void Start()
    {
        instance = GetComponent<AirSlicer>(); 
    }

    public int score = 0;

    public bool check;

    void TaskOnClick()
    {
        //old code for HW4, can delete
        AddScore();
        SendTrue();
        SendFalse();
    }

    //old function to test sending a score to server 
    public static void AddScore() 
    {
        //score++;
        //SendScoreToServer();
    }

    //test true server
    public void SendTrue()
    {
        check = true;
        SendCheckToServer();
    }

    //test false to server
    public void SendFalse()
    {
        check = false;
        SendCheckToServer();
    }


    //Will be call when player hit the obj
    public void SendSuccessfulHit()
    {
        ClientSend.PlayerHit();
    }

    //test for sending bool to server, not use in any other place
    private void SendCheckToServer()
    {
        ClientSend.Check(check);
    }

    //This function will be call when host click the start game button.
    public void StartGame()
    {
        //GameManager.playerControl = true;
        ClientSend.PlayerEnable();
    }

    //This function will be call when player click back button in the waiting room and disconnect from the server
    public void Disconnection()
    {
        Client.instance.Disconnect();
    }
    // This script will house all the player's data, like their username, as well as their score during a minigame, and overall minigames won while playing in a lobby. 
    // Note that this is different from player persistent data, like options. 

    public void SuccessfulHit()
    {
        //play animation
        Debug.Log("Player pressed a button!"); 
        instance.SuccessfulHit(); 
    }
}
