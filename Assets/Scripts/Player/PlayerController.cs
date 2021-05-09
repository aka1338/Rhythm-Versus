using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public void OnAction1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.CheckForValidHit();
        }
        Debug.Log("Action 1 pressed!");
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.CheckForValidHit();
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.PauseGame();
        }
    }
}
