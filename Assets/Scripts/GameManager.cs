using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO: Events that fire off based on how well timed a player's input was checked against the BeatSystem. 
    //The events are: PerfectHit, EarlyHit, LateHit, and Missed.  

    // This class should only be responsible for firing off events to other classes, as well as handling things that have to do with gamestate.
    // It should call upon UIManager and pause whatever it needs to, and will switch screens by calling upon UIManager enums. 
    // Also, this class should know what minigame is being played when, and listen for certain callback markers to trigger events in game. 
    // Responsible for initializing Conductor with the correct song. 
    // F.e., if the UI needs to know when a note has been successfully hit, they can subscribe to the events denoted within this class.  

    public static float keyDownTime;

    // Should be set to a PlayerPref. For now, adjust in editor. 
    public static float offset;

    // Just for the sake of testing, we're only putting one song here. 
    [FMODUnity.EventRef]
    public string song;

    public delegate void NoteTiming();
    public static event NoteTiming ValidHit;
    public static event NoteTiming MissedHit;

    public static event NoteTiming EarlyHit;
    public static event NoteTiming LateHit;

    public bool isPaused = false;

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
    public void CheckForValidHit()
    {
        keyDownTime = BeatSystem.timelinePosition;

        if (keyDownTime >= BeatSystem.markerTimeLinePosition - offset && keyDownTime <= BeatSystem.markerTimeLinePosition + offset && BeatSystem.markerTimeLinePosition != 0)
        {
            //Debug.Log("On beat!");
            ValidHit?.Invoke();
        }
        else
        {
            //Debug.Log("Off beat!"); 
            MissedHit?.Invoke();
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            ViewManager.Show<PauseMenuView>();
            isPaused = true;
            Conductor.PauseMusic();
        }
    }
    public void ResumeGame()
    {
        if (isPaused)
        {
            ViewManager.Show<MinigameView>();
            isPaused = false;
            Conductor.ResumeMusic();
        }
    }

    //TODO: This should take a parameter [FMODUnity.EventRef] public string song. 
    public void StartMinigame()
    {
        Conductor.CreateBeatInstance(song);
        Conductor.StartMusic();
    }

}
