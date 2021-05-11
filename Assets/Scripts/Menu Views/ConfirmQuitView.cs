using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmQuitView : View
{
    [SerializeField] private Button _yesButton, _noButton;
    public override void Initialize()
    {
        _yesButton.onClick.AddListener(() => Application.Quit());
        _noButton.onClick.AddListener(() => ViewManager.Show<MinigameView>());
    }

}