using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class AirSlicer : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    public GameObject[] prefab;
    public Collision collisionbox;

    public float offsetx = 10;
    public float offsety = 10; 
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
        Instantiate(prefab[0], new Vector3(cubeTransform.localPosition.x - offsetx, cubeTransform.localPosition.y - offsety, 0f), Quaternion.identity, cubeTransform);
    }
    private void SpawnCarrot()
    {
        Instantiate(prefab[1], new Vector3(4.9f, -6.03f, 0f), Quaternion.identity);
    }

    private void SpawnPotato()
    {
        Instantiate(prefab[2], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void SuccessfulHit()
    {
        // I don't know if this does anything lmfao 
        if (this != null)
        {
            cubeMaterial.DOColor(Color.green, 1);
            GameObject currentVeggieNote = GameObject.Find("VeggieNote(Clone)");
            currentVeggieNote.SetActive(false);
            DeleteDelay(currentVeggieNote);
            Destroy(Instantiate(prefab[3], new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity, cubeTransform), 1f);
        }
    }

    private void UnSuccessfulHit()
    {
        if (this != null)
        {
            cubeMaterial.DOColor(Color.red, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            StartCoroutine(DeleteDelay(other));
        }
 
    }

    // Waits a bit to ensure cube has reached it's final destination before being deleted, otherwise generates DOTween warnings. 
    IEnumerator DeleteDelay(Collider other)
     {
       yield return new WaitForSeconds(.4f);
        if (other != null) 
        {
            Debug.Log(other.gameObject.name);
            DOTween.Kill(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    IEnumerator DeleteDelay(GameObject gameObject)
    {
        yield return new WaitForSeconds(.5f);
        if (gameObject != null)
        {
            Debug.Log(gameObject.name);
            DOTween.Kill(gameObject);
            Destroy(gameObject);
        }
    }
}
