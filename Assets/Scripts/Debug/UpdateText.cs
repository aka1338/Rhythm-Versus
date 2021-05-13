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
        playerScore.SetText("Your score: " + GameManager.players[0].score);
        player2Score.SetText("Player 2's Score: " + GameManager.players[1].score);
        player3Score.SetText("Player 3's Score: " + GameManager.players[2].score);
    }
}
