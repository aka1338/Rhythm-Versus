using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    public static bool playerControl = false;//enable or disable player control to their character

    //TODO: Events that fire off based on how well timed a player's input was checked against the BeatSystem. 
    //The events are: PerfectHit, EarlyHit, LateHit, and Missed.  

    // This class should only be responsible for firing off events to other classes, as well as handling things that have to do with gamestate.
    // It should call upon UIManager and pause whatever it needs to, and will switch screens by calling upon UIManager enums. 
    // Also, this class should know what minigame is being played when, and listen for certain callback markers to trigger events in game. 
    // Responsible for initializing Conductor with the correct song. 
    // F.e., if the UI needs to know when a note has been successfully hit, they can subscribe to the events denoted within this class.  

    public static float keyDownTime;

    // Should be set to a PlayerPref. For now, adjust in editor. 
    public static float offset = 180;

    // Just for the sake of testing, we're only putting one song here. 
    [FMODUnity.EventRef]
    public string song;

    public delegate void NoteTiming();
    public static event NoteTiming ValidHit;
    public static event NoteTiming MissedHit;

    // For cool stuff later 
    //public static event NoteTiming EarlyHit;
    //public static event NoteTiming LateHit;

    // Pausing is disabled in multiplayer 

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

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }
        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public static void EnableControl()
    {
        playerControl = true;
    }

    public static bool isPaused = false;

    private void Start()
    {
        InputController.ActionOnePressed += CheckForValidHit;
        InputController.ActionTwoPressed += CheckForValidHit;
        InputController.PausePressed += PauseGame;
    }

    private void OnDisable()
    {
        InputController.ActionOnePressed -= CheckForValidHit;
        InputController.ActionTwoPressed -= CheckForValidHit;
        InputController.PausePressed -= PauseGame;
    }

    // Due to the nature of our GameManager, this actually calls during the Calibration Minigame. It's not that important, though. 
    public static void CheckForValidHit()
    {
        keyDownTime = BeatSystem.timelinePosition;

        // if marker is a note, then we can check for it's validity. 
        if (BeatSystem.marker.Length > 5)
        {
            if (BeatSystem.marker.Substring(0, 5).Equals("note-"))
            {
                // if marker is note, remove "note-" from string so that when player calls BeatSystem.marker, they get the data they need. 
                if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0)
                {
                    ValidHit?.Invoke();
                }
                else
                {
                    MissedHit?.Invoke();
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public static void PauseGame()
    {
        if (!isPaused)
        {
            ViewManager.Show<PauseMenuView>();
            isPaused = true;
            Conductor.PauseMusic();
        }
        else
            ResumeGame();
    }
    public static void ResumeGame()
    {
        if (isPaused)
        {
            ViewManager.Show<MinigameView>();
            isPaused = false;
            Conductor.ResumeMusic();
        }
    }

    public static void SetOffset(float _offset) 
    {
        offset = _offset;         
    }
    //TODO: This should take a parameter [FMODUnity.EventRef] public string song. 
    public void StartMinigame()
    {
        Conductor.CreateBeatInstance(song);
        Conductor.StartMusic();
    }

    public void EndMinigame()
    {
        Debug.Log("Minigame over!");
        Conductor.StopAndClear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchGame()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else 
        {
            SceneManager.LoadScene(0);
        }
    }
}
