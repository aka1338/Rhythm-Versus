using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;

    public int score = 1;

    public bool check;

    void TaskOnClick()
    {
        AddScore();
        SendTrue();
        SendFalse();
    }

    public static void AddScore() 
    {
        //score++;
        SendScoreToServer();
    }

    public void SendTrue()
    {
        check = true;
        SendCheckToServer();
    }

    public void SendFalse()
    {
        check = false;
        SendCheckToServer();
    }

    private static void SendScoreToServer()
    {
        ClientSend.AddScore(1);
    }

    private void SendCheckToServer()
    {
        ClientSend.Check(check);
    }

    public void StartGame()
    {
        //GameManager.playerControl = true;
        ClientSend.PlayerEnable();
    }
    // This script will house all the player's data, like their username, as well as their score during a minigame, and overall minigames won while playing in a lobby. 
    // Note that this is different from player persistent data, like options. 

}
