using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationMenuView : View
{
    [SerializeField] private Button _okButton, _checkOffsetButton, _backScreenButton;
    public override void Initialize()
    {
        _backScreenButton.onClick.AddListener(() => ViewManager.Show<MinigameSelectView>());
        _okButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _checkOffsetButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }
}