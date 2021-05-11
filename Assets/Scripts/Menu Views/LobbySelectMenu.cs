using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySelectMenu : View
{
    [SerializeField] private Button _hostLobbyButton, _joinLobbyButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<localVSonlineSelectorView>());
        _hostLobbyButton.onClick.AddListener(() => ViewManager.Show<HostLobbyWaitingView>());
        _joinLobbyButton.onClick.AddListener(() => ViewManager.Show<JoinLobbyWaitingView>());
    }
}