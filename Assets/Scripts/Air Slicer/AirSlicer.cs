using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class AirSlicer : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    public GameObject[] prefab;
    //public GameObject currentVeggieNote;
    public static float animationDuration;

    [FMODUnity.EventRef]
    public string[] sfx;

    void Start()
    {
        GameManager.ValidHit += SuccessfulHit;
        GameManager.MissedHit += UnSuccessfulHit;
   
        BeatSystem.OnMarker += SpawnNote;
    }

    void Update()
    {
        if (cubeTransform.position.y > 0.95)
        {
          StartCoroutine("DeleteNote");
        }
    }
    private void OnDisable()
    {
        GameManager.ValidHit -= SuccessfulHit;
        GameManager.MissedHit -= UnSuccessfulHit;
        BeatSystem.OnMarker -= SpawnNote;

    }

    private void SpawnNote()
    {
        animationDuration = BeatSystem.secPerBeat;
        Debug.Log(animationDuration); 
        if (BeatSystem.marker.Substring(0,5).Equals("Onion") || BeatSystem.marker.Substring(0,4).Equals("Carrot") || BeatSystem.marker.Substring(0,4).Equals("Potato"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 5), animationDuration * .3f);
            animationDuration = BeatSystem.secPerBeat;
        }
    }

    private void SpawnOnion()
    {
        Instantiate(prefab[0], new Vector3(-4.9f, -5.03f, 0f), Quaternion.identity);
    }
    private void SpawnCarrot()
    {
        Instantiate(prefab[1], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void SpawnPotato()
    {
        Instantiate(prefab[2], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void SuccessfulHit()
    {
        //if (note != null)
        //{
        cubeMaterial.DOColor(Color.green, 1);
        GameObject currentVeggieNote = GameObject.Find("VeggieNote(Clone)");
        Destroy(Instantiate(prefab[3], new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity), 1f);
        DOTween.Kill(currentVeggieNote);
        Destroy(currentVeggieNote);

            //Destroy(currentVeggieNote);
        Debug.Log("This should have removed the oldest clone");

            //Debug.Log("Making a function call to DestroyVeggieNote()");
            //AirSlicer.DestroyVeggieNote();
            //Destroy(Instantiate(this.cutVeggie, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity), 2f);
            //Instantiate(cutVeggie, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);     
       // }
    }

    private void UnSuccessfulHit()
    {
        //if (note != null)
        //{
            cubeMaterial.DOColor(Color.red, 1);
            GameObject currentVeggieNote = GameObject.Find("VeggieNote(Clone)");
            //Instantiate(cutVeggie, new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity);
            Destroy(currentVeggieNote);
       // }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!!!!");
        DOTween.Kill(other.gameObject);
        Destroy(other.gameObject);
    }

    // Waits a bit to ensure cube has reached it's final destination before being deleted, otherwise generates DOTween warnings. 
    IEnumerator DeleteNote()
     {
       yield return new WaitForSeconds(0.1f);
       //Destroy(note);
     }
}
