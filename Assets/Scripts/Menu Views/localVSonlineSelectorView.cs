using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localVSonlineSelectorView : View
{
    [SerializeField] private Button _onlineButton, _localButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<PlayMenuView>());
        _onlineButton.onClick.AddListener(() => ViewManager.Show<LobbySelectMenu>());
        _localButton.onClick.AddListener(() => ViewManager.Show<MinigameSelectView>());
    }
}