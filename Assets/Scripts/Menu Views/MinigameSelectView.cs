using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameSelectView : View
{
    [SerializeField] private Button _airSlicerButton, _batterUpButton;
    public override void Initialize()
    {
        _airSlicerButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
        _batterUpButton.onClick.AddListener(() => Application.Quit());
    }
}
