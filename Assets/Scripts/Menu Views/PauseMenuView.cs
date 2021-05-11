using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : View
{
    [SerializeField] private Button _resumeButton, _quitButton, _settingsButton;
    public override void Initialize()
    {
        _resumeButton.onClick.AddListener(() => Debug.Log("Game is supposed to unpause here!"));
        _quitButton.onClick.AddListener(() => ViewManager.Show<ConfirmQuitView>());
        _settingsButton.onClick.AddListener(() => ViewManager.Show<SettingsView>());
    }

}
