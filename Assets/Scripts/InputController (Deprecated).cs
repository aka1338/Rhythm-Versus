using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode actionOne;
    public KeyCode actionTwo;
    public KeyCode pause;

    public delegate void PlayerInput();
    public static event PlayerInput ActionOnePressed;
    public static event PlayerInput ActionTwoPressed;
    public static event PlayerInput PausePressed;

    public static float keyDownTime;

    public int ID;

    // Due to the nature of our GameManager, this actually calls during the Calibration Minigame. It's not that important, though. 
    public static bool CheckForValidHit(KeyCode keyCode)
    {

        if (Input.GetKeyDown(keyCode))
        {
            keyDownTime = BeatSystem.timelinePosition;
        }

        // if marker is a note, then we can check for it's validity. 
        //if (BeatSystem.marker.Substring(0, 5).Equals("note-"))
        //{
        // if marker is note, remove "note-" from string so that when player calls BeatSystem.marker, they get the data they need. 
        if (keyDownTime >= BeatSystem.markerTimeLinePosition - GameManager.offset && keyDownTime <= BeatSystem.markerTimeLinePosition + GameManager.offset && BeatSystem.markerTimeLinePosition != 0)
        {
            Player.AddScore();

            return true;
        }
        else
        {
            return false;
        }
    }

    // TODO: Prevent key holding for multiple input. 
    void OnGUI()
    {
            if (anonymousKeyDown(actionOne))
            {
                ActionOnePressed?.Invoke();
            }
            if (anonymousKeyDown(actionTwo))
            {
                ActionTwoPressed?.Invoke();
            }
            if (anonymousKeyDown(pause))
            {
                PausePressed?.Invoke();
            }

        }

    // helper function (Since OnGui sends both a keycode and char event, not using this results in two events firing instead of one. 
    private bool anonymousKeyDown(KeyCode key)
    {
        if (Event.current.type == EventType.KeyDown)
            return (Event.current.keyCode == key);
        return false;
    }
}
