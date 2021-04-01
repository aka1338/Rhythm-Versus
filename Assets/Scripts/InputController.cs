using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode actionOne;
    public KeyCode actionTwo;
    public KeyCode pause;

    public delegate void PlayerInput();
    public static event PlayerInput ActionOnePressed;
    public static event PlayerInput ActionTwoPressed;
    public static event PlayerInput pausePressed;

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
            pausePressed?.Invoke();
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
