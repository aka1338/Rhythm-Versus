
using UnityEngine;
using UnityEngine.UI;

public class ResultsView : View
{
    public Button backToMainMenu; 
    public override void Initialize()
    {
        backToMainMenu.onClick.AddListener(() => ViewManager.Show<PlayMenuView>()); 
    }
}
