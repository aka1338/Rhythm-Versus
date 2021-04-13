using UnityEngine;

public class AirSlicer : MonoBehaviour
{
    public Transform[] prefab;
    public static float animationDuration;

    [FMODUnity.EventRef]
    public string[] sfx;

    void Start()
    {
        BeatSystem.OnMarker += SpawnNote;

        InputController.ActionOnePressed += PlaySwish;
    }

    private void OnDisable()
    {
        BeatSystem.OnMarker -= SpawnNote;
        InputController.ActionOnePressed -= PlaySwish;

    }

    private void SpawnNote()
    {
        animationDuration = BeatSystem.secPerBeat;
        Debug.Log(animationDuration); 
        if (BeatSystem.marker.Substring(0,5).Equals("Onion") || BeatSystem.marker.Substring(0,4).Equals("Carrot") || BeatSystem.marker.Substring(0,4).Equals("Potato"))
        {
            Invoke("Spawn" + BeatSystem.marker.Substring(0, 5), animationDuration * 0f);
            animationDuration = BeatSystem.secPerBeat;
        }
    }

    private void SpawnOnion()
    {
        Instantiate(prefab[0], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }
    private void SpawnCarrot()
    {
        Instantiate(prefab[1], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void SpawnPotato()
    {
        Instantiate(prefab[2], new Vector3(-5.32f, -6.03f, 0f), Quaternion.identity);
    }

    private void PlaySwish()
    {
        Conductor.PlaySFX(sfx[1]);
    }
}
