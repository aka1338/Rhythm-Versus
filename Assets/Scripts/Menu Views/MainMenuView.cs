
using UnityEngine;
using UnityEngine.UI; 

public class MainMenuView : View
{
    [SerializeField] private Button _startButton; 
    public override void Initialize()
    {
        _startButton.onClick.AddListener(() => ViewManager.Show<MinigameView>()); 
    }
}
