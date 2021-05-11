using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostLobbyWaitingView : View
{
    [SerializeField] private Button _startButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<LobbySelectMenu>());
        _startButton.onClick.AddListener(() => ViewManager.Show<MinigameSelectView>());
    }
}