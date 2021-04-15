 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Events; // this namespace makes the magic, tho
 using UnityEngine.SceneManagement;

 public class Button : MonoBehaviour {
 
    public int index; 

    void Start()
    {

    }

     // This captures a click as long as you have a collider, even if it's set to just be a trigger, and nothing blocking it.
     // However, it will still capture even if a Gui button is on top of it, so make sure you aren't checking this while also checking Gui
     // Only other colliders block and it's not as manageable as Canvas Groups.
 
     private void OnMouseDown()
     {
         print("You clicked the cube!");
         Debug.Log("Scene loading...");
         SceneManager.LoadScene(index);
     }
 
 }