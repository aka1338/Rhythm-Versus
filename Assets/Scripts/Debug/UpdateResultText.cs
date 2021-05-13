using TMPro;
using UnityEngine;

public class UpdateResultText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerScore, player2Score, player3Score, resultsText;

    public int placeholderScore = 0;
    public string placeholderString; 
    void Update()
    {
        if (GameManager.players.ContainsKey(1))
            playerScore.SetText(GameManager.players[1].username + "s score: " + GameManager.players[1].score);

        if (GameManager.players.ContainsKey(2))
            player2Score.SetText(GameManager.players[2].username + "s score: " + GameManager.players[2].score);

        if (GameManager.players.ContainsKey(3))
            player3Score.SetText(GameManager.players[3].username + "s score: " + GameManager.players[3].score);

        //resultsText.SetText <- Use this to set the text!
        //if player 1 win
        if ((GameManager.players.ContainsKey(1) && GameManager.players.ContainsKey(2) && GameManager.players.ContainsKey(3)) || GameManager.players.ContainsKey(1) && GameManager.players.ContainsKey(2))
        {
            if (!GameManager.players.ContainsKey(3)) 
            {
                placeholderScore = 0;
            } 
            else
            {
                placeholderScore = GameManager.players[3].score;
                placeholderString = GameManager.players[3].username; 
            }
            if (GameManager.players[1].score > GameManager.players[2].score && GameManager.players[1].score > placeholderScore)
            {
                resultsText.SetText(GameManager.players[1].username + " win the game.");
            }
            //if player 1 and 2 have even highest score
            else if (GameManager.players[1].score == GameManager.players[2].score && GameManager.players[1].score > placeholderScore)
            {
                resultsText.SetText(GameManager.players[1].username + "and " + GameManager.players[2].username + " win the game.");
            }
            //if player 2 have the highest score
            else if (GameManager.players[2].score > placeholderScore)
            {
                resultsText.SetText(GameManager.players[2].username + " win the game.");
            }
            //if player 2 and 3 have even highest score
            else if (GameManager.players[2].score == placeholderScore && GameManager.players[2].score > GameManager.players[1].score)
            {
                resultsText.SetText(GameManager.players[2].username + "and " + placeholderString + " win the game.");
            }
            //if player 1 and 3 have even highest score
            else if (GameManager.players[1].score == placeholderScore && GameManager.players[1].score > GameManager.players[2].score)
            {
                resultsText.SetText(GameManager.players[1].username + "and " + placeholderString + " win the game.");
            }
            //if all player have same score
            else if (GameManager.players[1].score == GameManager.players[2].score && GameManager.players[2].score == placeholderScore)
            {
                resultsText.SetText("This game is a draw.");
            }
            //if all of the above false then player 3 win
            else
            {
                resultsText.SetText(placeholderString + " win the game.");
            }
        }
    }
}
