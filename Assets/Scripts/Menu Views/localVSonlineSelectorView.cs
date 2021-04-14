using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localVSonlineSelectorView : View
{
    [SerializeField] private Button _onlineButton, _localButton;
    public override void Initialize()
    {
        _onlineButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _localButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }
}