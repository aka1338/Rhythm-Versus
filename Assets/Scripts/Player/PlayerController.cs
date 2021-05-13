using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static AirSlicer instance;

    private void Start()
    {
        instance = GetComponent<AirSlicer>(); 
    }
    public void OnAction1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            instance.CheckForValidHit();
        }
    }
    public void OnAction2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            instance.CheckForValidHit();
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
