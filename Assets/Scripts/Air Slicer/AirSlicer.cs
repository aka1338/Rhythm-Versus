using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class AirSlicer : MonoBehaviour
{
    public Transform referencePoint;
    public GameObject[] prefab;
    public Collision collisionbox;
    GameObject currentVeggieNote;

    public float offsetx = 10;
    public float offsety = 10;
    public static float animationDuration;

    void Start()
    {
        GameManager.ValidHit += SuccessfulHit;
        GameManager.MissedHit += UnSuccessfulHit;

        BeatSystem.OnMarker += SpawnNote;
    }

    void Update()
    {
        if (referencePoint.position.y > 0.95)
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
        if (BeatSystem.marker.Substring(0, 5).Equals("Onion")) 
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 5), animationDuration * .3f);
        }

        if (BeatSystem.marker.Substring(0, 6).Equals("Carrot"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 6), animationDuration * .3f);
        }

        if (BeatSystem.marker.Substring(0, 6).Equals("Potato")) 
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 6), animationDuration * .3f);
        }
    }

    private void SpawnOnion()
    {
        currentVeggieNote = Instantiate(prefab[2], new Vector3(referencePoint.localPosition.x, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
        currentVeggieNote.transform.DOScale(new Vector3(.15f, .15f, .15f), animationDuration);
    }
    private void SpawnCarrot()
    {
        currentVeggieNote = Instantiate(prefab[1], new Vector3(referencePoint.localPosition.x + offsetx, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
    }

    private void SpawnPotato()
    {
        currentVeggieNote = Instantiate(prefab[0], new Vector3(referencePoint.localPosition.x - offsetx, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
    }

    private void SuccessfulHit()
    {
        // I don't know if this does anything lmfao 
        if (currentVeggieNote != null)
        {
            Debug.Log("currentVeggieNote.name: " + currentVeggieNote.name);

            // currentVeggieNote = GameObject.Find("CarrotNote(Clone)");
            currentVeggieNote.SetActive(false);
            DeleteDelay(currentVeggieNote);

            if (currentVeggieNote.name == "PotatoNote(Clone)")
            {
                Destroy(Instantiate(prefab[3], new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity, referencePoint), 1f);
            }
            else if (currentVeggieNote.name == "CarrotNote(Clone)")
            {
                Destroy(Instantiate(prefab[4], new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity, referencePoint), 1f);
            }
            else
            {
                Destroy(Instantiate(prefab[5], new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity, referencePoint), 1f);
            }
        }
    }

    private void UnSuccessfulHit()
    {
        if (this != null)
        {
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null)
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