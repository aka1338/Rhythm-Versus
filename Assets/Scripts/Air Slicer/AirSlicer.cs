using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class AirSlicer : MonoBehaviour
{
    public Transform referencePoint;
    public GameObject[] prefab;
    
    public Collision collisionbox;
    public static GameObject currentVeggieNote;
    public static Dictionary<int, PlayerManager> _players = new Dictionary<int, PlayerManager>();

    public float offsetx = 10;
    public float offsety = 10;
    public static float animationDuration;

    public static float keyDownTime;

    public PlayerManager playerManagerInstance; 
    public GameManager instance; 

    // Should be set to a PlayerPref. For now, adjust in editor. 
    public static float offset = 180;
    public static void UpdatePlayers(Dictionary<int, PlayerManager> players) 
    {
        _players = players; 
    }
    void Start()
    {
        BeatSystem.OnMarker += SpawnNote;
        playerManagerInstance = GetComponent<PlayerManager>(); 
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
        BeatSystem.OnMarker -= SpawnNote;
    }

    private void SpawnNote()
    {
        animationDuration = BeatSystem.secPerBeat;
        if (BeatSystem.marker.Substring(0, 5).Equals("Onion"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 5), animationDuration * .3f);
        }

        else if (BeatSystem.marker.Substring(0, 6).Equals("Carrot"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 6), animationDuration * .3f);
        }

        else if (BeatSystem.marker.Substring(0, 6).Equals("Potato"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 6), animationDuration * .3f);
        }
    }

    private void SpawnOnion()
    {
        currentVeggieNote = Instantiate(prefab[2], new Vector3(referencePoint.localPosition.x, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
        currentVeggieNote.transform.DOScale(new Vector3(.15f, .15f, .15f), animationDuration);
        currentVeggieNote.transform.DORotate(new Vector3(0, 0, 360), animationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
    private void SpawnCarrot()
    {
        currentVeggieNote = Instantiate(prefab[1], new Vector3(referencePoint.localPosition.x + offsetx, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
        currentVeggieNote.transform.DORotate(new Vector3(0, 0, 360), animationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }

    private void SpawnPotato()
    {
        currentVeggieNote = Instantiate(prefab[0], new Vector3(referencePoint.localPosition.x - offsetx, referencePoint.localPosition.y - offsety, 0f), Quaternion.identity, referencePoint);
        currentVeggieNote.transform.DORotate(new Vector3(0, 0, 360), animationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }

    public void SuccessfulHit()
    {
        // I don't know if this does anything lmfao 
        Debug.Log("Local test"); 
        if (currentVeggieNote != null)
        {
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

            Debug.Log("This should work!");
            Debug.Log(GameManager.isLocal); 

            if (!GameManager.isLocal) 
            {
                Instantiate(prefab[5], new Vector3(referencePoint.transform.position.x, referencePoint.transform.position.y+2, 0f), Quaternion.identity, referencePoint);
                playerManagerInstance.SendSuccessfulHit();
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
    static IEnumerator DeleteDelay(Collider other)
    {
        yield return new WaitForSeconds(.4f);
        if (other != null)
        {
            DOTween.Kill(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    static IEnumerator DeleteDelay(GameObject gameObject)
    {
        yield return new WaitForSeconds(.5f);
        if (gameObject != null)
        {
            DOTween.Kill(gameObject);
            Destroy(gameObject);
        }
    }

    public bool CheckForValidHit()
    {
        keyDownTime = BeatSystem.timelinePosition;
        if (BeatSystem.marker != null)
        {
            // if marker is a note, then we can check for it's validity. 
            if (BeatSystem.marker.Length > 5)
            {
                if (BeatSystem.marker.Substring(0, 5).Equals("note-"))
                {
                    // if marker is note, remove "note-" from string so that when player calls BeatSystem.marker, they get the data they need. 
                    if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0)
                    {
                        SuccessfulHit(); 
                    }
                    else
                    {
                        UnSuccessfulHit(); 
                    }
                }
            }
        }

        return false;
    }
}