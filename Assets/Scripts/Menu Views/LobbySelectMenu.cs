using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySelectMenu : View
{
    [SerializeField] private Button _createLobbyButton, _joinLobbyButton;
    public override void Initialize()
    {
        _createLobbyButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _joinLobbyButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }
}