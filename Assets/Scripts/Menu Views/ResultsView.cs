
using UnityEngine;
using UnityEngine.UI;

public class ResultsView : View
{
    [SerializeField] public Button backToMainMenu; 
    public override void Initialize()
    {
        backToMainMenu.onClick.AddListener(() => ViewManager.Show<PlayMenuView>()); 
    }
}
