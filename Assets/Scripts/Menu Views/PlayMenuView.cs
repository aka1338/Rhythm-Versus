using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuView : View
{
    [SerializeField] private Button _playButton, _exitButton;
    public override void Initialize()
    {
        _playButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _exitButton.onClick.AddListener(() => Application.Quit());
    }

}
