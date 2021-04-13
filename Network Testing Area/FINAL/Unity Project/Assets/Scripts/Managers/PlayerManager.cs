using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    //rythum vs
    public int score = 0;
    //public Button button;

    void start()
    {
        //Button btn = button.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick); ; 
    }

    void TaskOnClick()
    {
        AddScore();
    }

    public void AddScore()
    {
        score++;
        SendScoreToServer();
    }

    private void SendScoreToServer()
    {
        ClientSend.AddScore(score);
    }
}
