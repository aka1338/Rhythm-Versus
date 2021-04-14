using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : View
{
    [SerializeField] private Button _VolumeUpButton, _VolumeDownButton, _backButton, resumeButton;
    public override void Initialize()
    {
        _VolumeUpButton.onClick.AddListener(() => Application.Quit());
        _VolumeDownButton.onClick.AddListener(() => Application.Quit());
        _backButton.onClick.AddListener(() => ViewManager.Show<PauseMenuView>());
        resumeButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }

}