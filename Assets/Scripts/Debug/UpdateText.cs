using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerScore, player2Score, player3Score; 

    void Update()
    {
        if (GameManager.players.ContainsKey(1))
        playerScore.SetText(GameManager.players[1].username + "s score: " + GameManager.players[1].score);

        if (GameManager.players.ContainsKey(2)) 
        player2Score.SetText(GameManager.players[2].username + "s score: " + GameManager.players[2].score);

        if (GameManager.players.ContainsKey(3))
        player3Score.SetText(GameManager.players[3].username + "s score: " + GameManager.players[3].score);
    }
}
