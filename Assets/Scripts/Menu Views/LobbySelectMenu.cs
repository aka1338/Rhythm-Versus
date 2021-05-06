using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySelectMenu : View
{
    [SerializeField] private Button _createLobbyButton, _joinLobbyButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<localVSonlineSelectorView>());
        _createLobbyButton.onClick.AddListener(() => ViewManager.Show<MinigameSelectView>());
        _joinLobbyButton.onClick.AddListener(() => ViewManager.Show<MinigameSelectView>());
    }
}