using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 instance;

    public GameObject startMenu;
    public InputField usernameField;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        //startMenu.SetActive(false);
        //usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }
}
