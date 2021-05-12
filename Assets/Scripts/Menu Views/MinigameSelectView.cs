using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameSelectView : View
{
    [SerializeField] private Button _airSlicerButton, _batterUpButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<LobbySelectMenu>());
        _airSlicerButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _batterUpButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }
}
