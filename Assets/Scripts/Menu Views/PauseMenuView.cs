using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : View
{
    [SerializeField] private Button _resumeButton;
    public override void Initialize()
    {
        _resumeButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }

}
