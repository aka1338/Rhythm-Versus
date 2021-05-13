using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class LoadLocalMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    public static void LoadLocalMinigameInstance()
    {
        SceneManager.LoadScene(1); 
    }

}
