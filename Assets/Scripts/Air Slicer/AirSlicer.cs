using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirSlicer : MonoBehaviour
{
    public GameObject[] prefab;
    public static float animationDuration;
    private GameObject currentVeggieNote;

    //private List<GameObject> activeVeggieNotes;
    private Queue<GameObject> activeVeggieNotes = new Queue<GameObject>();

    [FMODUnity.EventRef]
    public string[] sfx;

    void Start()
    {
        //activeVeggieNotes = new List<GameObject>();
        BeatSystem.OnMarker += SpawnNote;
    }

    private void OnDisable()
    {
        BeatSystem.OnMarker -= SpawnNote;

    }

    private void SpawnNote()
    {
        animationDuration = BeatSystem.secPerBeat;
        Debug.Log(animationDuration); 
        if (BeatSystem.marker.Substring(0,5).Equals("Onion") || BeatSystem.marker.Substring(0,4).Equals("Carrot") || BeatSystem.marker.Substring(0,4).Equals("Potato"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 5), animationDuration * .5f);
            animationDuration = BeatSystem.secPerBeat;
        }
    }

    private void SpawnOnion()
    {
        // --------------------- Queue Method ----------------------------------//
        currentVeggieNote = Instantiate(prefab[0], new Vector3(-4.9f, -5.03f, 0f), Quaternion.identity);
        activeVeggieNotes.Enqueue(currentVeggieNote);
        Debug.Log("Queue Size:" + activeVeggieNotes.Count);
        
        // ---------------------- List Method -----------------------------------//
        //GameObject newVeggieNote = Instantiate(prefab[0], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
        //activeVeggieNotes.Add(newVeggieNote);


        // ---------------------- Current Method (deletes all clones) -----------//
        //Instantiate(prefab[0], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
        //Destroy(Instantiate(prefab[0], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity), 1.5f);
    }
    private void SpawnCarrot()
    {
        Instantiate(prefab[1], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void SpawnPotato()
    {
        Instantiate(prefab[2], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    public void DestroyVeggieNote()
    {
        if (activeVeggieNotes.Count > 0)
        {
            Debug.Log("Total Notes: " + activeVeggieNotes.Count);
            // VeggieNote is popped from Queue and then Destroyed
            GameObject poppedVeggieNote = activeVeggieNotes.Dequeue();
            //poppedVeggieNote.SetActive(false);
            Destroy(poppedVeggieNote, 1.25f);

            //Destroy(activeVeggieNotes[0]);
        }
    }
}
