using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScoreText : MonoBehaviour
{
    // Start is called before the first frame update

   

    [SerializeField]
    private TMP_Text score;

    void Start()
    {
        GameManager.ValidHit += UpdateText;
    }

    private void OnDestroy()
    {
        GameManager.ValidHit -= UpdateText;

    }

    // Update is called once per frame
    void UpdateText() => score.SetText("Score : " + Player.score);
}
